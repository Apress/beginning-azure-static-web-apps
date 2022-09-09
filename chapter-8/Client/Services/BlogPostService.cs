using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Models;
namespace Client.Services;
public class BlogPostService
{
    private readonly HttpClient http;
    private readonly NavigationManager navigationManager;
    private List<BlogPost> blogPostCache = new();
    public BlogPostService(
    HttpClient http,
    NavigationManager navigationManager)
    {
        ArgumentNullException.ThrowIfNull(http, nameof(http));
        ArgumentNullException.ThrowIfNull(navigationManager, nameof(navigationManager));
        this.http = http;
        this.navigationManager = navigationManager;
    }

    public async Task<BlogPost?> GetBlogPost(Guid blogPostId, string author)
    {
        BlogPost? blogPost = blogPostCache.FirstOrDefault(bp => bp.Id == blogPostId && bp.Author == author);
        if (blogPost is null)
        {
            var result = await http.GetAsync($"api/blogposts/{author}/{blogPostId}");
            if (!result.IsSuccessStatusCode)
            {
                navigationManager.NavigateTo("404");
                return null;
            }
            blogPost = await result.Content.ReadFromJsonAsync<BlogPost>();
            if (blogPost is null)
            {
                navigationManager.NavigateTo("404");
                return null;
            }
            blogPostCache.Add(blogPost);
        }
        return blogPost;
    }
}