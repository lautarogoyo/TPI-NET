using Data;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/auth/login", ([FromBody] LoginRequestDTO dto) =>
            {
                var usuariosRepo = new UsuarioRepository();
                var personasRepo = new PersonaRepository();

                var username = (dto.Usuario ?? "").Trim();
                var password = (dto.Clave ?? "").Trim();

                // 🔽 usa el método normalizado (ver sección B)
                var user = usuariosRepo.GetByNombreUsuarioNormalized(username);
                if (user is null) return Results.BadRequest(new { error = "user-not-found" });

                if (!user.Habilitado) return Results.BadRequest(new { error = "user-disabled" });

                if (!string.Equals(user.Clave?.Trim(), password, StringComparison.Ordinal))
                    return Results.BadRequest(new { error = "bad-password" });

                var persona = personasRepo.Get(user.IDPersona);
                if (persona is null) return Results.BadRequest(new { error = "persona-missing" });

                var role = persona.TipoPersona == 2 ? "Profesor" : "Alumno";
                var token = BuildJwt(app.Configuration, user.NombreUsuario, persona.IDPersona, persona.TipoPersona, role);

                return Results.Ok(new LoginResponseDTO
                {
                    Token = token,
                    UserName = user.NombreUsuario,
                    PersonaId = persona.IDPersona,
                    TipoPersona = persona.TipoPersona,
                    Role = role
                });
            })
            .AllowAnonymous()
            .DisableAntiforgery()
            .WithName("AuthLogin")
            .Produces<LoginResponseDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithOpenApi();
        }

        private static string BuildJwt(IConfiguration cfg, string username, int personaId, int tipoPersona, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username),
                new("personaId", personaId.ToString()),
                new("tipoPersona", tipoPersona.ToString()),
                new(ClaimTypes.Role, role)
            };

            var jwt = new JwtSecurityToken(
                issuer: cfg["Jwt:Issuer"],
                audience: cfg["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
