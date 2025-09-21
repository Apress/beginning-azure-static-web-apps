using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
namespace StaticWebAppAuthentication.Client;
public static class StaticWebAppAuthenticationExtensions
{
    public static IServiceCollection AddStaticWebAppsAuthentication(this IServiceCollection services)
    {
        return services
            .AddAuthorizationCore()
             .AddScoped<AuthenticationStateProvider, StaticWebAppsAuthenticationStateProvider>();
    }
}