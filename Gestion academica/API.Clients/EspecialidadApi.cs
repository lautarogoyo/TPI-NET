using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTOs;


namespace API.Clients
{
    public class EspecialidadApi
    {

        private static readonly HttpClient client = new HttpClient();

        static EspecialidadApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/"); // <-- ajustá puerto de tu WebAPI
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<EspecialidadDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"especialidades/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EspecialidadDTO>();
                }
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener especialidad Id {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener especialidad Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener especialidad Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<EspecialidadDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("especialidades");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<EspecialidadDTO>>() 
                           ?? new List<EspecialidadDTO>();
                }
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener especialidades. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener especialidades: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener especialidades: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(EspecialidadDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("especialidades", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear especialidad. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear especialidad: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear especialidad: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(EspecialidadDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("especialidades", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar especialidad Id {dto.IDEspecialidad}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar especialidad Id {dto.IDEspecialidad}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar especialidad Id {dto.IDEspecialidad}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"especialidades/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar especialidad Id {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar especialidad Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar especialidad Id {id}: {ex.Message}", ex);
            }
        }

        // Búsqueda por criterio (usa /especialidades?q=texto). 
        // Si en tu API usás /especialidades/criteria?texto=..., cambiá la URL abajo.
        public static async Task<IEnumerable<EspecialidadDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"especialidades?q={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<EspecialidadDTO>>() 
                           ?? new List<EspecialidadDTO>();
                }
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar especialidades. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar especialidades: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar especialidades: {ex.Message}", ex);
            }
        }
    }
}