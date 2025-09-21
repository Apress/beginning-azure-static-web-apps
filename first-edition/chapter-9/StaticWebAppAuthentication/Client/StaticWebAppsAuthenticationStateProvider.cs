using Microsoft.AspNetCore.Components.Authorization;
using StaticWebAppAuthentication.Models;
using System.Net.Http.Json;
using System.Security.Claims;
namespace StaticWebAppAuthentication.Client;
public class StaticWebAppsAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient http;
    public StaticWebAppsAuthenticationStateProvider(HttpClient httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));
        this.http = httpClient;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var clientPrincipal = await GetClientPrincipal();
            var claimsPrincipal = GetClaimsFromClientClaimsPrincipal(clientPrincipal);
            return new AuthenticationState(claimsPrincipal);
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }

    public static ClaimsPrincipal GetClaimsFromClientClaimsPrincipal(ClientPrincipal principal)
    {
        principal.UserRoles =
        principal.UserRoles?.Except(new[] { "anonymous" }, StringComparer.CurrentCultureIgnoreCase) ?? new List<string>();
        if (!principal.UserRoles.Any())
        {
            return new ClaimsPrincipal();
        }
        ClaimsIdentity identity = AdaptToClaimsIdentity(principal);
        return new ClaimsPrincipal(identity);
    }

    private static ClaimsIdentity AdaptToClaimsIdentity(ClientPrincipal principal)
    {
        var identity = new ClaimsIdentity(principal.IdentityProvider);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, principal.UserId!));
        identity.AddClaim(new Claim(ClaimTypes.Name, principal.UserDetails!));
        identity.AddClaims(principal.UserRoles!.Select(r => new Claim(ClaimTypes.Role, r)));
        return identity;
    }

    private async Task<ClientPrincipal> GetClientPrincipal()
    {
        var data = await http.GetFromJsonAsync<AuthenticationData>("/.auth/me");
        var clientPrincipal = data?.ClientPrincipal ?? new ClientPrincipal();
        return clientPrincipal;
    }
}