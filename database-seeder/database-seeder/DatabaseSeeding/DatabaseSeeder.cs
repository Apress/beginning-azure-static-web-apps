using CosmosDBPlayground.DatabaseSeeding.SeedBlogposts;
using Microsoft.Azure.Cosmos;

namespace CosmosDBPlayground.DatabaseSeeding;

/// <summary>
/// Creates a database and container inside of an Azure CosmosDB account
///   for the Beginning Static Web Apps with Blazor book and seeds with 7 blogposts
/// </summary>
internal class DatabaseSeeder: IDisposable
{
    const string EndpointUri = "<Your CosmosDB Endpoint URL>";
    const string PrimaryKey = "<Your CosmosDB Primary Key>";
    
    const string databaseId = "SwaBlog";
    const string containerId = "BlogContainer";
    const string stringsContainerId = "StringContainer";

    private readonly CosmosClient cosmosClient;

    internal DatabaseSeeder()
    {
        cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
    }

    internal async Task CreateAndSeedDatabase()
    {
        var container = await CreateDatabaseAndContainer();
        await SeedDatabase(container);

        var stringsContainer = await CreateStringsContainer();
        await SeedStringsContainer(stringsContainer);
    }

    private async Task SeedDatabase(Container container)
    {
        List<Blogpost> allPosts = new()
        {
            APIAuthorization.Blogpost,
            FirstStaticWebApp.Blogpost,
            LoadingFromApi.Blogpost,
            Navigation.Blogpost,
            SettingUpTheAngularStaticWebAppPipeline.Blogpost,
            YourFirstAngularApp.Blogpost,
            YourFirstPage.Blogpost
        };

        foreach (var blogPost in allPosts)
        {
            var result = await container.CreateItemAsync(blogPost); 
            Console.WriteLine($"Cost of creating {blogPost.Title}: {result.RequestCharge}");
        };

        Console.WriteLine("Blogposts seeded");
        
    }

    private async Task<Container> CreateDatabaseAndContainer()
    {
        try
        {
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine($"Created Database: {database.Id}");

            Container container = await database.CreateContainerIfNotExistsAsync(containerId, "/Author");

            Console.WriteLine($"Created Container: {container.Id}");

            return container;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            throw;
        }
    }

    private async Task<Container> CreateStringsContainer()
    {
        try
        {
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Container container = await database.CreateContainerIfNotExistsAsync(stringsContainerId, "/PartitionKey");

            Console.WriteLine($"Created Strings Container: {container.Id}");

            return container;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            throw;
        }
    }

    private async Task SeedStringsContainer(Container container)
    {
        var constants = typeof(Constants).GetProperties();
        foreach (var constant in constants)
        {
            var value = constant.GetValue(null)?.ToString();
            if (value != null)
            {
                var item = new
                {
                    id = value,
                    PartitionKey = "Tags"
                };

                var result = await container.CreateItemAsync(item);
                Console.WriteLine($"Cost of creating {constant.Name}: {result.RequestCharge}");
            }
        }

        Console.WriteLine("Strings seeded");
    }

    public void Dispose()
    {
        cosmosClient.Dispose();
    }
}
