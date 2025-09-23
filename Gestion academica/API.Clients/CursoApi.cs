using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class CursoApi
    {
        private static readonly HttpClient client = new HttpClient();

        static CursoApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/"); // ajustá el puerto de tu WebAPI si es distinto
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<CursoDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"cursos/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CursoDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener curso Id {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener curso Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener curso Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<CursoDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("cursos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CursoDTO>>() ?? new List<CursoDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener cursos. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener cursos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener cursos: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(CursoDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("cursos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear curso. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear curso: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear curso: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(CursoDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("cursos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar curso Id {dto.IdCurso}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar curso Id {dto.IdCurso}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar curso Id {dto.IdCurso}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"cursos/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar curso Id {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar curso Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar curso Id {id}: {ex.Message}", ex);
            }
        }

        // Si querés buscar por descripción (criterio), asegurate de que la API tenga un endpoint como /cursos?q=xxx
        public static async Task<IEnumerable<CursoDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"cursos?q={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CursoDTO>>() ?? new List<CursoDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar cursos. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar cursos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar cursos: {ex.Message}", ex);
            }
        }
    }
}
