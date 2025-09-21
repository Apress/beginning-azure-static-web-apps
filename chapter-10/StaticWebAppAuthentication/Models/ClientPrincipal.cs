namespace StaticWebAppAuthentication.Models;
public record ClientPrincipal(
    string? IdentityProvider,
    string? UserId,
    string? UserDetails,
    IEnumerable<string>? UserRoles);