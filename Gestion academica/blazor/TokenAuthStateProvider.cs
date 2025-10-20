using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;


public class TokenAuthStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _js;
    private ClaimsPrincipal _current = new(new ClaimsIdentity()); // anónimo

    public TokenAuthStateProvider(IJSRuntime js) => _js = js;

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => Task.FromResult(new AuthenticationState(_current));

    public async Task ForceRefreshAsync()
    {
        string? token = null;
        try
        {
            token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");
        }
        catch
        {
            _current = new(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_current)));
            return;
        }

        if (string.IsNullOrWhiteSpace(token))
        {
            _current = new(new ClaimsIdentity());
        }
        else
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            const string RoleUri = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";


            IEnumerable<Claim> MapRoleClaims(IEnumerable<Claim> claims)
            {
                const string RoleUri = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

                foreach (var c in claims)
                {
                    var isRole =
                        c.Type.Equals("role", StringComparison.OrdinalIgnoreCase) ||
                        c.Type.Equals("roles", StringComparison.OrdinalIgnoreCase) ||
                        c.Type.Equals(RoleUri, StringComparison.OrdinalIgnoreCase);

                    if (!isRole)
                    {
                        // No es claim de rol -> lo dejo pasar tal cual
                        yield return c;
                        continue;
                    }

                    var v = c.Value?.Trim();
                    if (string.IsNullOrEmpty(v))
                        continue;

                    // 1) Si viene como array JSON -> junto roles en una lista y luego los "yield-eo" fuera del try
                    if (v.StartsWith("["))
                    {
                        List<string> roles = new();
                        try
                        {
                            using var doc = JsonDocument.Parse(v);
                            foreach (var el in doc.RootElement.EnumerateArray())
                            {
                                var r = el.GetString();
                                if (!string.IsNullOrWhiteSpace(r))
                                    roles.Add(r);
                            }
                        }
                        catch
                        {
                            // si falló el parseo, dejamos roles vacío y seguimos al split genérico abajo
                        }

                        if (roles.Count > 0)
                        {
                            foreach (var r in roles)
                                yield return new Claim(ClaimTypes.Role, r);
                            continue; // ya procesado
                        }
                        // si no se pudo parsear, cae al split genérico
                    }

                    // 2) String simple o separado por comas/espacios
                    foreach (var r in v.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                        yield return new Claim(ClaimTypes.Role, r);
                }
            }


            var mappedClaims = MapRoleClaims(jwt.Claims);

            var identity = new ClaimsIdentity(
                mappedClaims,
                authenticationType: "jwt",
                nameType: ClaimTypes.Name,
                roleType: ClaimTypes.Role);

            _current = new ClaimsPrincipal(identity);
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_current)));
    }

    public async Task SetTokenAsync(string? token)
    {
        if (string.IsNullOrEmpty(token))
            await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");
        else
            await _js.InvokeVoidAsync("localStorage.setItem", "authToken", token);

        await ForceRefreshAsync();
    }
}
