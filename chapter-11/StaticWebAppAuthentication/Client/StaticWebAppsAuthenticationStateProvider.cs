using Microsoft.AspNetCore.Components.Authorization;
using StaticWebAppAuthentication.Models;
using System.Net.Http.Json;
using System.Security.Claims;
namespace StaticWebAppAuthentication.Client;

public class StaticWebAppsAuthenticationStateProvider   
        (HttpClient httpClient) : AuthenticationStateProvider
{
    private readonly HttpClient httpClient =
        httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private record TryGetAsyncResult<T>(bool Success, T? Value);
    private const string AuthMeEndpoint = "/.auth/me";
    private const string AnonymousRole = "anonymous";

    public override async Task<AuthenticationState>
GetAuthenticationStateAsync()
    {
        var userNotAuthenticatedAuthState =
        new AuthenticationState(new ClaimsPrincipal());
        try
        {
            var getClientPrincipalResponse = await TryGetClientPrincipalAsync();
            if (getClientPrincipalResponse is null)
            {
                return userNotAuthenticatedAuthState;
            }
            var hasClaimsPrincipal = TryGetClaimsFromClientClaimsPrincipal(
                getClientPrincipalResponse.Value!,
                out var claimsPrincipal);
            if (hasClaimsPrincipal)
            {
                return new AuthenticationState(claimsPrincipal!);
            }
            return userNotAuthenticatedAuthState;
        }
        catch
        {
            return userNotAuthenticatedAuthState;
        }
    }

    private static bool TryGetClaimsFromClientClaimsPrincipal(
        ClientPrincipal principal,
        out ClaimsPrincipal? claimsPrincipal) 
    {
        claimsPrincipal = null;

        var editedRoles = principal.UserRoles?.Except([AnonymousRole], StringComparer.CurrentCultureIgnoreCase) ?? [];

        if (!editedRoles.Any())
        {
            return false;
        }

        ClaimsIdentity identity = AdaptToClaimsIdentity(principal);
        claimsPrincipal = new ClaimsPrincipal(identity);
        return true;
    }

    private static ClaimsIdentity AdaptToClaimsIdentity(ClientPrincipal principal)
    {
        var identity =
        new ClaimsIdentity(principal.IdentityProvider);
        identity.AddClaim(new Claim(
            ClaimTypes.NameIdentifier,
            principal.UserId!));
        identity.AddClaim(
            new Claim(
            ClaimTypes.Name,
            principal.UserDetails!));
        identity.AddClaims(
            principal.UserRoles!
            .Select(r => new Claim(ClaimTypes.Role, r)));
        return identity;
    }

    private async Task<TryGetAsyncResult<ClientPrincipal>>TryGetClientPrincipalAsync()
    {
        var authData = await httpClient.
        GetFromJsonAsync<AuthenticationData>(AuthMeEndpoint);
        if (authData is null)
        {
            return new(false, null);
        }
        var clientPrincipal = authData.ClientPrincipal;
        if (clientPrincipal is null)
        {
            return new(false, null);
        }
        return new(true, clientPrincipal);
    }   
}