using blazor;
using blazor.Components;
using Microsoft.AspNetCore.Components.Authorization;
// using Microsoft.AspNetCore.Authentication;            // <- ya no lo necesitamos
// using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;


var builder = WebApplication.CreateBuilder(args);

// Razor Components
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// 🔐 UI basada en TOKEN (no cookies)
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthStateProvider>();

// (Opcional) si NO vas a usar cookies en absoluto, quitá esto:
// builder.Services.AddAuthentication("Cookies").AddCookie("Cookies", o => { ... });
// y NO llames app.UseAuthentication();

builder.Services.AddHttpClient("WebApi", c => c.BaseAddress = new Uri("https://localhost:7111")).AddHttpMessageHandler<AuthHeaderHandler>(); // ⬅️ agrega el token a cada request
; 
builder.Services.AddScoped<blazor.ApiAuthSession>();
builder.Services.AddTransient<AuthHeaderHandler>();
builder.Services.AddScoped<API.Clients.EspecialidadApi>();
builder.Services.AddScoped<API.Clients.MateriaApi>();
builder.Services.AddScoped<API.Clients.ComisionApi>();
builder.Services.AddScoped<API.Clients.PlanApi>();
builder.Services.AddScoped<API.Clients.PersonaApi>();
builder.Services.AddScoped<API.Clients.InscripcionApi>();
builder.Services.AddScoped<API.Clients.CursoApi>();
builder.Services.AddScoped<API.Clients.UsuarioApi>();
builder.Services.AddScoped<API.Clients.AuthApi>();


var app = builder.Build();

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

// ❌ Ya NO necesitamos /auth/signin ni /auth/signout (eran para cookies)
// podés borrar esos endpoints.

app.Run();
