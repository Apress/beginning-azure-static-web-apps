using Client;
using Client.Services;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StaticWebAppAuthentication.Client;
using System.Text.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
new HttpClient
{
    BaseAddress =
new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddScoped<BlogpostSummaryService>();
builder.Services.AddScoped<BlogpostService>();
builder.Services.AddScoped<TagsService>();
builder.Services.AddScoped(sp =>
    {
        var httpClient = sp.GetRequiredService<HttpClient>();
        return new GraphQLHttpClient(
            new GraphQLHttpClientOptions
            {
                EndPoint =
                new Uri($"{httpClient.BaseAddress}data-api/graphql")
            },
            new SystemTextJsonSerializer(
                new JsonSerializerOptions(
                 JsonSerializerDefaults.Web)), httpClient);
    });

builder.Services.AddStaticWebAppsAuthentication();
builder.Services.AddCascadingAuthenticationState();

await builder.Build().RunAsync();
