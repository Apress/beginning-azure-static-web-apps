using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Models;
using StaticWebAppAuthentication.Api;
using StaticWebAppAuthentication.Models;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Cosmos;

namespace Api;

public class Blogposts
{
    private readonly ILogger<Blogposts> _logger;

    public Blogposts(ILogger<Blogposts> logger)
    {
        _logger = logger;
    }

    [Function($"{nameof(Blogposts)}_GetAll")]
    public IActionResult GetAll(
        [HttpTrigger(AuthorizationLevel.Function,
            "get",
            Route = "blogposts")]
            HttpRequest req,
        [CosmosDBInput(
            databaseName: "SwaBlog",
            containerName: "BlogContainer",
            Connection = "CosmosDbConnectionString",
            SqlQuery =@"
            SELECT
            c.id,
            c.Title,
            c.Author,
            c.PublishedDate,
            LEFT(c.BlogpostMarkdown, 500)
            As BlogpostMarkdown,
            LENGTH(c.BlogpostMarkdown) <= 500
            As PreviewIsComplete,
            c.Tags
            FROM c
            WHERE c.Status = 2")]
            IEnumerable<Blogpost> blogposts)
    {
        return new OkObjectResult(blogposts);
    }

    [Function($"{nameof(Blogposts)}_GetSingle")]
    public IActionResult GetSingle(
        [HttpTrigger(
            AuthorizationLevel.Function,
            "get",
            Route = "blogposts/{author}/{id}")
            ] HttpRequest req,
        [CosmosDBInput(
            databaseName: "SwaBlog",
            containerName: "BlogContainer",
            Connection = "CosmosDbConnectionString",
            SqlQuery =@"
            SELECT
            c.id,
            c.Title,
            c.Author,
            c.PublishedDate,c.BlogpostMarkdown,
            c.Tags
            FROM c
            WHERE c.Status = 2
            AND c.id = {id}
            AND c.Author = {author}")
            ] IEnumerable<Blogpost> blogposts)
    {
        if (!blogposts.Any())
        {
            return new NotFoundResult();
        }
        return new OkObjectResult(blogposts.First());
    }

    [Function($"{nameof(Blogposts)}_Post")]
    public static async Task<IActionResult> PostBlogpostAsync(
        [HttpTrigger(
            AuthorizationLevel.Anonymous,
            "post",
            Route = "blogposts")] HttpRequestData req,
        [CosmosDBInput
            (Connection = "CosmosDbConnectionString")]
        CosmosClient client)
    {
        var blogpost = await req.ReadFromJsonAsync<Blogpost>();
        if (blogpost is null || string.IsNullOrEmpty(blogpost.Title))
        {
            return new BadRequestObjectResult("Blogpost is incomplete");
        }
        
        if (blogpost.Id != default)
        {
            return new BadRequestObjectResult("Id must be empty");
        }
        (var authorized, var clientPrincipal) = IsAuthorized(req);
        if (!authorized)
        {
            return new UnauthorizedResult();
        }

        var database = client.GetDatabase("SwaBlog");
        var id = Guid.CreateVersion7();
        var author = clientPrincipal!.UserDetails!;

        var savedBlogpost =
            await SaveBlogpostAsync(blogpost, id, author, database);
        await SaveTagsAsync(blogpost, database);
        return new OkObjectResult(savedBlogpost);
    }

    [Function($"{nameof(Blogposts)}_Put")]
    public async Task<IActionResult> PutBlogpostAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put",
            Route = "blogposts")] HttpRequestData req,
        [CosmosDBInput(Connection = "CosmosDbConnectionString")]
            CosmosClient client)
    {
        var blogpost = await req.ReadFromJsonAsync<Blogpost>();
        if (blogpost is null || string.IsNullOrEmpty(blogpost.Title))
        {
            return new BadRequestObjectResult("Blogpost is incomplete");
        }

        (var authorized, var clientPrincipal) = IsAuthorized(req);
        if (!authorized)
        {
            return new UnauthorizedObjectResult("Auth Token is Invalid");
        }

        var database = client.GetDatabase("SwaBlog");
        var container = database.GetContainer("BlogContainer");
        Blogpost? currentBlogpost;
        try
        {
            var blogResponse = await container.ReadItemAsync<Blogpost>(
                id: blogpost.Id.ToString(),
                partitionKey: new PartitionKey(blogpost.Author));
            currentBlogpost = blogResponse.Resource;
        }
        catch (CosmosException)
        {
            return new NotFoundResult();
        }

        if (currentBlogpost is null)
        {
            return new NotFoundResult();
        }

        if (currentBlogpost.Author != clientPrincipal!.UserDetails)
        {
            return new StatusCodeResult(
                StatusCodes.Status403Forbidden);
        }

        var savedBlogpost =
        await SaveBlogpostAsync(blogpost, blogpost.Id, blogpost.Author, database);
        await SaveTagsAsync(blogpost, database);
        return new OkObjectResult(savedBlogpost);
    }

    private static async Task<dynamic> SaveBlogpostAsync(
        Blogpost blogpost,
        Guid id,
        string author,
        Database database)
    {
        dynamic savedBlogPost = new
        {
            id = id.ToString(),
            Author = author,
            PublishedDate = DateTime.Now,
            Status = 2,
            blogpost.Title,
            blogpost.Tags,
            blogpost.BlogpostMarkdown,
        };
        var container = database.GetContainer("BlogContainer");
        await container.UpsertItemAsync(
        savedBlogPost, new PartitionKey(author));
        return savedBlogPost;
}

    private static async Task SaveTagsAsync(Blogpost blogpost, Database database)
    {
        var tagsContainer =
        database.GetContainer("StringContainer");
        List<Task> tagInserts = [];
        foreach (string tag in blogpost.Tags)
        {
            tagInserts.Add(tagsContainer.UpsertItemAsync(
            new { PartitionKey = "Tags", id = tag },
            new PartitionKey("Tags")));
        }
        await Task.WhenAll(tagInserts);
    }

    [Function($"{nameof(Blogposts)}_Delete")]
    public async Task<IActionResult> DeleteBlogpost(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete",
            Route = "blogposts/{author}/{id}")] HttpRequestData req,
            string id,
            string author,
        [CosmosDBInput(
            databaseName: "SwaBlog",
            containerName: "BlogContainer",
            Connection = "CosmosDbConnectionString")]
            Container blogpostContainer)
    {
        Blogpost? currentBlogpost = null;
        try
        {
            var blogResponse =  
                await blogpostContainer.ReadItemAsync<Blogpost>(
                    id: id,
                    partitionKey: new PartitionKey(author));
            currentBlogpost = blogResponse.Resource;
        }
        catch (CosmosException ex)
            when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return new NoContentResult();
        }

        (var authorized, var clientPrincipal) = IsAuthorized(req);
        if (!authorized)
        {
            return new UnauthorizedObjectResult("Auth Token is Invalid");
        }
        
        if (currentBlogpost.Author != clientPrincipal!.UserDetails)
        {
            return new StatusCodeResult(
            StatusCodes.Status403Forbidden);
        }

        await blogpostContainer.DeleteItemAsync<Blogpost>(
            id: id,
            partitionKey: new PartitionKey(author));
        
        return new NoContentResult();
    }

    private static (bool Authorized, ClientPrincipal? ClientPrincipal) IsAuthorized(HttpRequestData req)
    {
        if (StaticWebAppApiAuthentication
            .TryParseHttpHeaderForClientPrincipal
            (req.Headers, out var clientPrincipal)
            && !string.IsNullOrWhiteSpace(clientPrincipal!.UserDetails))
        {
            return (true, clientPrincipal);
        }
        return (false, null);
    }
}