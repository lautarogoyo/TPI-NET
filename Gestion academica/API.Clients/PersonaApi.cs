using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class PersonaApi
    {
        private static readonly HttpClient client = new HttpClient();

        static PersonaApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/"); // ⚠️ Ajustá si usás otro puerto
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<PersonaDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"personas/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PersonaDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener persona Id {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener persona Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener persona Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<PersonaDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("personas");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<PersonaDTO>>() ?? new List<PersonaDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener personas. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener personas: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener personas: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(PersonaDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("personas", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear persona. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear persona: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear persona: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(PersonaDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("personas", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar persona Id {dto.IDPersona}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar persona Id {dto.IDPersona}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar persona Id {dto.IDPersona}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"personas/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar persona Id {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar persona Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar persona Id {id}: {ex.Message}", ex);
            }
        }
    }
}
