using StaticWebAppAuthentication.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace StaticWebAppAuthentication.Api;

public static class StaticWebAppApiAuthentication
{
    private static readonly JsonSerializerOptions jsonSerializerOptions
        = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    public static bool TryParseHttpHeaderForClientPrincipal(
        HttpHeaders headers,
        out ClientPrincipal? clientPrincipal)
    {
        if (!headers.Contains("x-ms-client-principal"))
        {
            clientPrincipal = null;
            return false;
        }
        try
        {
            var data = headers
                .First(header =>
                header
                .Key
                .Equals
                ("x-ms-client-principal", StringComparison.CurrentCultureIgnoreCase));
            var decoded = Convert.FromBase64String(data.Value.First());
            var json = Encoding.UTF8.GetString(decoded);
            clientPrincipal =
                JsonSerializer.Deserialize<ClientPrincipal>(json,
                jsonSerializerOptions);
            return clientPrincipal is not null;
        }
        catch
        {
            clientPrincipal = null;
            return false;
        }
    }
}