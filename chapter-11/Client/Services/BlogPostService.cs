using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Models;
using System.Text;
using System.Text.Json;

namespace Client.Services;

public class BlogpostService(HttpClient httpClient,
NavigationManager navigationManager)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly NavigationManager _navigationManager = navigationManager;
    private List<Blogpost> blogpostCache = new();
    public event EventHandler? BlogpostChanged;

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

    public async Task<Blogpost> Create(Blogpost blogpost)
    {
        ArgumentNullException.ThrowIfNull(blogpost, nameof(blogpost));

        var result = await _httpClient.PostAsJsonAsync("api/blogposts", blogpost);
        result.EnsureSuccessStatusCode();
        
        var savedBlogpost = await result
            .Content
            .ReadFromJsonAsync<Blogpost>();
        blogpostCache.Add(savedBlogpost!);
        
        OnBlogpostsChanged();
        return savedBlogpost!;
    }

    public async Task Update(Blogpost blogpost)
    { 
        ArgumentNullException.ThrowIfNull(blogpost, nameof(blogpost));

        var results = await _httpClient.PutAsJsonAsync("api/blogposts", blogpost);
        results.EnsureSuccessStatusCode();
        var updatedBlogpost = await results
            .Content
            .ReadFromJsonAsync<Blogpost>();
        if (blogpostCache != null)
        { 
            var index = blogpostCache.FindIndex(b => b.Id == blogpost.Id && b.Author == blogpost.Author);
            if (index >= 0)
            {
                blogpostCache[index] = updatedBlogpost!;
            }

            OnBlogpostsChanged();
        }
    }

    public async Task Delete(Guid id, string author)
    {
        var deleteURL = $"api/blogposts/{author}/{id}";
    
        var result = await _httpClient.DeleteAsync(deleteURL);
        result.EnsureSuccessStatusCode();
        blogpostCache.RemoveAll(
            blogpost => blogpost.Id == id
            && blogpost.Author == author);
        
        OnBlogpostsChanged();
    }

    private void OnBlogpostsChanged()
    {
        BlogpostChanged?.Invoke(this, EventArgs.Empty);
    }
}