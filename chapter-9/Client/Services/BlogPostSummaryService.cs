using Models;
using System.Net.Http.Json;

namespace Client.Services;

public class BlogpostSummaryService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
    public List<Blogpost>? Summaries;


    public async Task LoadBlogpostSummaries()
    {
        if (Summaries == null)
        {
            Summaries = await _httpClient.GetFromJsonAsync<List<Blogpost>> ("api/blogposts");
        }
    }
}