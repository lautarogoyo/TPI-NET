using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOs;

namespace API.Clients
{
    public static class DocenteCursoApi
    {
        private static readonly HttpClient client = new HttpClient();

        static DocenteCursoApi()
        {
            client.BaseAddress = new Uri("https://localhost:7111/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // === GET ALL ===
        public static async Task<IEnumerable<DocenteCurso>> GetAllAsync()
        {
            var response = await client.GetAsync("docentescursos");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCurso>>()
                   ?? new List<DocenteCurso>();
        }

        // === GET (por IDs compuestos) ===
        public static async Task<DocenteCurso?> GetAsync(int idCurso, int idDocente)
        {
            var response = await client.GetAsync($"docentescursos/{idCurso}/{idDocente}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<DocenteCurso>();

            return null;
        }

        // === ADD ===
        public static async Task AddAsync(DocenteCurso dto)
        {
            var response = await client.PostAsJsonAsync("docentescursos", dto);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar DocenteCurso: {error}");
            }
        }

        // === UPDATE ===
        public static async Task UpdateAsync(DocenteCurso dto)
        {
            var response = await client.PutAsJsonAsync("docentescursos", dto);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar DocenteCurso: {error}");
            }
        }

        // === DELETE (por IDs compuestos) ===
        public static async Task DeleteAsync(int idCurso, int idDocente)
        {
            var response = await client.DeleteAsync($"docentescursos/{idCurso}/{idDocente}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar DocenteCurso: {error}");
            }
        }

        // === FILTRO opcional ===
        public static async Task<IEnumerable<DocenteCurso>> GetByCriteriaAsync(string texto)
        {
            var response = await client.GetAsync($"docentescursos?q={Uri.EscapeDataString(texto)}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCurso>>()
                   ?? new List<DocenteCurso>();
        }
    }
}
