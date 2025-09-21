using Client;
using Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StaticWebAppAuthentication.Client;

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

builder.Services.AddStaticWebAppsAuthentication();
builder.Services.AddCascadingAuthenticationState();

await builder.Build().RunAsync();
