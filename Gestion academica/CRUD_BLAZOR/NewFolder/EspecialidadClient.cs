using System.Net.Http.Json;
using DTOs;

public class EspecialidadClient
{
    private readonly HttpClient _http;
    public EspecialidadClient(IHttpClientFactory f) => _http = f.CreateClient("WebApi");

    public Task<List<EspecialidadDTO>?> GetAllAsync()
        => _http.GetFromJsonAsync<List<EspecialidadDTO>>("especialidades");

    public Task<EspecialidadDTO?> GetAsync(int id)
        => _http.GetFromJsonAsync<EspecialidadDTO>($"especialidades/{id}");

    public async Task CreateAsync(EspecialidadDTO dto)
        => (await _http.PostAsJsonAsync("especialidades", dto)).EnsureSuccessStatusCode();

    public async Task UpdateAsync(EspecialidadDTO dto)
        => (await _http.PutAsJsonAsync("especialidades", dto)).EnsureSuccessStatusCode();

    public async Task DeleteAsync(int id)
        => (await _http.DeleteAsync($"especialidades/{id}")).EnsureSuccessStatusCode();
}
