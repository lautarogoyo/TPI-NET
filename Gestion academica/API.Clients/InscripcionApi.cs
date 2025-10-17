using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class InscripcionApi
    {
        private static readonly HttpClient client = new HttpClient();

        static InscripcionApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<InscripcionDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"inscripciones/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<InscripcionDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener inscripción Id {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripción Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener inscripción Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<InscripcionDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("inscripciones");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<InscripcionDTO>>() ?? new List<InscripcionDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener inscripciones. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripciones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener inscripciones: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(InscripcionDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("inscripciones", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear inscripción. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear inscripción: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear inscripción: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(InscripcionDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("inscripciones", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar inscripción Id {dto.IDInscripcion}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar inscripción Id {dto.IDInscripcion}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar inscripción Id {dto.IDInscripcion}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"inscripciones/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar inscripción Id {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar inscripción Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar inscripción Id {id}: {ex.Message}", ex);
            }
        }
    }
}
