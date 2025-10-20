using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class AuthApi
    {
        private static readonly HttpClient client = new HttpClient();

        static AuthApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/"); // <-- ajustá al puerto real de tu WebAPI
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Llama a POST /auth/login y devuelve el token + datos del usuario si es correcto.
        /// Devuelve null si las credenciales son inválidas (401/400 con error conocido).
        /// Lanza excepción ante otros errores (conexión, 500, etc.).
        /// </summary>
        public static async Task<LoginResponseDTO?> LoginAsync(string usuario, string clave)
        {
            try
            {
                var req = new LoginRequestDTO
                {
                    Usuario = (usuario ?? "").Trim(),
                    Clave = (clave ?? "").Trim()
                };

                var resp = await client.PostAsJsonAsync("auth/login", req);

                // 👇 agrega esto
                var body = await resp.Content.ReadAsStringAsync();
                Console.WriteLine($"[LOGIN] Status={(int)resp.StatusCode} {resp.StatusCode} Body={body}");

                if (resp.StatusCode == HttpStatusCode.Unauthorized ||
                    resp.StatusCode == HttpStatusCode.BadRequest)
                    return null;

                if (!resp.IsSuccessStatusCode)
                    throw new Exception($"Error al iniciar sesión. Status: {resp.StatusCode}. Detalle: {body}");

                return await resp.Content.ReadFromJsonAsync<LoginResponseDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al iniciar sesión: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// No llama a la API (porque el logout lo hacés limpiando el token en cliente).
        /// Lo dejo por simetría si querés invocarlo desde la UI.
        /// </summary>
        public static Task LogoutAsync() => Task.CompletedTask;
    }
}
