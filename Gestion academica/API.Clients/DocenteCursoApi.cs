using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class DocenteCursoApi
    {
        private static readonly HttpClient client = new HttpClient();

        static DocenteCursoApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<DocenteCurso?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"docentecurso/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<DocenteCurso>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener docente curso con ID {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener docente curso con ID {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener docente curso con ID {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<DocenteCurso>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("docentecurso");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCurso>>() ?? new List<DocenteCurso>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener docentes curso. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener docentes curso: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener docentes curso: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(DocenteCurso dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("docentecurso", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear docente curso. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear docente curso: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear docente curso: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(DocenteCurso dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("docentecurso", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar docente curso. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar docente curso: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar docente curso: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"docentecurso/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar docente curso con ID {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar docente curso con ID {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar docente curso con ID {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<DocenteCurso>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"docentecurso?q={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCurso>>() ?? new List<DocenteCurso>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar docentes curso. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar docentes curso: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar docentes curso: {ex.Message}", ex);
            }
        }
    }
}
