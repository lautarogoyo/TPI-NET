using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public class MateriaApi
    {
        private static readonly HttpClient client = new HttpClient();

        static MateriaApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/"); // ajustá el puerto si es distinto
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<MateriaDTO?> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"materias/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<MateriaDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener materia Id {id}. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener materia Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener materia Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<MateriaDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("materias");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<MateriaDTO>>() ?? new List<MateriaDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener materias. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener materias: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener materias: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(MateriaDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("materias", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear materia. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear materia: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear materia: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(MateriaDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("materias", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar materia Id {dto.IDMateria}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar materia Id {dto.IDMateria}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar materia Id {dto.IDMateria}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"materias/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar materia Id {id}. Status: {response.StatusCode}. Detalle: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar materia Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar materia Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<MateriaDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"materias?q={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<MateriaDTO>>() ?? new List<MateriaDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar materias. Status: {response.StatusCode}. Detalle: {error}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar materias: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar materias: {ex.Message}", ex);
            }
        }
    }
}
