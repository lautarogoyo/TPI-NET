using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class ModuloUsuarioApi
    {
        private static readonly HttpClient client = new HttpClient();

        static ModuloUsuarioApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<ModuloUsuarioDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"modulosusuario/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ModuloUsuarioDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener módulo usuario ID {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener módulo usuario ID {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener módulo usuario ID {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ModuloUsuarioDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("modulosusuario");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ModuloUsuarioDTO>>() ?? new List<ModuloUsuarioDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener módulos usuario. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener módulos usuario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener módulos usuario: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(ModuloUsuarioDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("modulosusuario", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear módulo usuario. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear módulo usuario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear módulo usuario: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(ModuloUsuarioDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("modulosusuario", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar módulo usuario ID {dto.IDModuloUsuario}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar módulo usuario ID {dto.IDModuloUsuario}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar módulo usuario ID {dto.IDModuloUsuario}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"modulosusuario/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar módulo usuario ID {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar módulo usuario ID {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar módulo usuario ID {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ModuloUsuarioDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"modulosusuario?q={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ModuloUsuarioDTO>>() ?? new List<ModuloUsuarioDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar módulos usuario. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar módulos usuario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar módulos usuario: {ex.Message}", ex);
            }
        }
    }
}
