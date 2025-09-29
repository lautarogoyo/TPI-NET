using API.Clients;
using CRUD_BLAZOR.Components;

var builder = WebApplication.CreateBuilder(args);

// 1) Servicios (ANTES de Build)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// HttpClient nombrado hacia tu WebAPI
builder.Services.AddHttpClient("WebApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7111"); // API HTTPS real
});
builder.Services.AddScoped<EspecialidadClient>();


// 2) Build
var app = builder.Build();

// 3) Pipeline (DESPUÉS de Build)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
