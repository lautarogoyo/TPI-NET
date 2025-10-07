using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class ModuloApi
    {
        private static readonly HttpClient client = new HttpClient();

        static ModuloApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<ModuloDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"modulos/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ModuloDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener módulo ID {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener módulo ID {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener módulo ID {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ModuloDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("modulos");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ModuloDTO>>() ?? new List<ModuloDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener módulos. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener módulos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener módulos: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(ModuloDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("modulos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear módulo. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear módulo: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear módulo: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(ModuloDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("modulos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar módulo ID {dto.IDModulo}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar módulo ID {dto.IDModulo}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar módulo ID {dto.IDModulo}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"modulos/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar módulo ID {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar módulo ID {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar módulo ID {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ModuloDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"modulos?q={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ModuloDTO>>() ?? new List<ModuloDTO>();
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar módulos. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar módulos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar módulos: {ex.Message}", ex);
            }
        }
    }
}
