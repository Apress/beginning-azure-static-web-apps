using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Models;

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
}