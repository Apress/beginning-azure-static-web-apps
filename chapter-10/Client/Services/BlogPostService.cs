using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Models;
namespace Client.Services;
public class BlogpostService(HttpClient httpClient,
NavigationManager navigationManager)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly NavigationManager _navigationManager = navigationManager;
    private List<Blogpost> blogpostCache = new();

    public async Task<Blogpost?> GetBlogpost(Guid blogpostId, string author)
    {
        Blogpost? blogpost = blogpostCache.FirstOrDefault(bp => bp.Id == blogpostId && bp.Author == author);
        if (blogpost is null)
        {
            var result = await _httpClient.GetAsync($"api/blogposts/{author}/{blogpostId}");
            if (!result.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("404");
                return null;
            }
           
            blogpost = await result.Content.ReadFromJsonAsync<Blogpost>();

            if (blogpost is null)
            {
                _navigationManager.NavigateTo("404");
                return null;
            }
            blogpostCache.Add(blogpost);
        }
        return blogpost;
    }
}