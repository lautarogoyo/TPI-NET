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

        public static async Task<IEnumerable<DocenteCursoDTO>> GetAllAsync()
        {
            var response = await client.GetAsync("docentescursos");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCursoDTO>>()
                   ?? new List<DocenteCursoDTO>();
        }

        public static async Task<DocenteCursoDTO?> GetAsync(int idDocenteCurso)
        {
            var response = await client.GetAsync($"docentescursos/{idDocenteCurso}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<DocenteCursoDTO>();

            return null;
        }

        public static async Task AddAsync(DocenteCursoDTO dto)
        {
            var response = await client.PostAsJsonAsync("docentescursos", dto);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar DocenteCurso: {error}");
            }
        }

        public static async Task UpdateAsync(DocenteCursoDTO dto)
        {
            var response = await client.PutAsJsonAsync("docentescursos", dto);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar DocenteCurso: {error}");
            }
        }
        public static async Task DeleteAsync(int idDocenteCurso)
        {
            var response = await client.DeleteAsync($"docentescursos/{idDocenteCurso}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar DocenteCurso: {error}");
            }
        }
        public static async Task<IEnumerable<DocenteCursoDTO>> GetByCriteriaAsync(string texto)
        {
            var response = await client.GetAsync($"docentescursos?q={Uri.EscapeDataString(texto)}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCursoDTO>>()
                   ?? new List<DocenteCursoDTO>();
        }
    }
}
