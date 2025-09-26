using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class ComisionApi
    {
        private static readonly HttpClient client = new HttpClient();

        static ComisionApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/"); // ajustá el puerto si es distinto
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<ComisionDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"comisiones/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<ComisionDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener comisión Id {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener comisión Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener comisión Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ComisionDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("comisiones");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ComisionDTO>>() ?? new List<ComisionDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener comisiones. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener comisiones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener comisiones: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(ComisionDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("comisiones", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear comisión. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear comisión: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear comisión: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(ComisionDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("comisiones", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar comisión Id {dto.IDComision}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar comisión Id {dto.IDComision}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar comisión Id {dto.IDComision}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"comisiones/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar comisión Id {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar comisión Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar comisión Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ComisionDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"comisiones?q={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ComisionDTO>>() ?? new List<ComisionDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar comisiones. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar comisiones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar comisiones: {ex.Message}", ex);
            }
        }
    }
}
