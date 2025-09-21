using GraphQL;
using GraphQL.Client.Http;
namespace Client.Services;
public class TagsService : IDisposable
{
    private readonly GraphQLHttpClient _graphQLClient;
    private readonly BlogpostService _blogpostService;
    private const string query = @"
        query GetAll {
            stringItems(filter: { PartitionKey: { eq: ""Tags"" } }) {
                items {
                    id
                    PartitionKey
                }
            }
        }";

    public List<string> Tags { get; private set; } = [];
    
    public TagsService(
        GraphQLHttpClient graphQLHttpClient,
        BlogpostService blogpostService)
    {
        _graphQLClient = graphQLHttpClient;
        _blogpostService = blogpostService;
        _blogpostService.BlogpostChanged += OnBlogpostsChanged;
    }

    public async Task LoadTags(bool forceLoad = false)
    {
        if (!Tags.Any() || forceLoad)
        {
            var result = await _graphQLClient.SendQueryAsync<Data>(
            new GraphQLRequest
            {
                Query = query
            });
            Tags = [.. result.Data.StringItems.Items.Select(item => item.Id)];
        }
    }

    public void Dispose()
    {
        _blogpostService.BlogpostChanged -= OnBlogpostsChanged;
    }

    private async void OnBlogpostsChanged(object? sender, EventArgs e)
    {
        await LoadTags(true);
    }

    // Records needed to deserialize the response
    public record Data(StringItemList StringItems);
    public record StringItemList(StringItem[] Items);
    public record StringItem(string Id);
}
