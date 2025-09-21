using Newtonsoft.Json;

namespace CosmosDBPlayground.DatabaseSeeding;

internal record Blogpost
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public DateTime? PublishedDate { get; set; }
    public required string BlogpostMarkdown { get; set; }
    public required IEnumerable<string> Tags { get; set; }
    public Status Status { get; set; }

}

internal enum Status
{
    Draft = 1,
    Published = 2,
    Deleted = 3
}
