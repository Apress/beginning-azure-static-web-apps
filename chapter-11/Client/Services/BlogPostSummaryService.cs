using Models;
using System.Net.Http.Json;

namespace Client.Services;

public class BlogpostSummaryService : IDisposable
{
    public event EventHandler? SummariesRefreshed;
    private readonly HttpClient _httpClient;
    public List<Blogpost>? Summaries;
    private BlogpostService _blogpostService;

    public BlogpostSummaryService(HttpClient httpClient, BlogpostService blogpostService)
    {
        _httpClient = httpClient;
        _blogpostService = blogpostService;
        _blogpostService.BlogpostChanged += OnBlogpostsChanged;
    }

    public async Task LoadBlogpostSummaries(bool forceLoad = false)
    {
        if (Summaries == null || forceLoad)
        {
            Summaries = await _httpClient.GetFromJsonAsync<List<Blogpost>>("api/blogposts");
            SummariesRefreshed?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Dispose()
    {
        _blogpostService.BlogpostChanged -= OnBlogpostsChanged;
    }

    private async void OnBlogpostsChanged(object? sender, EventArgs e)
    {
        await LoadBlogpostSummaries(true);
    }
}