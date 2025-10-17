using blazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("WebApi", c => c.BaseAddress = new Uri("https://localhost:7111"));
builder.Services.AddScoped<API.Clients.EspecialidadApi>();
builder.Services.AddScoped<API.Clients.MateriaApi>();
builder.Services.AddScoped<API.Clients.ComisionApi>();
builder.Services.AddScoped<API.Clients.PlanApi>();
builder.Services.AddScoped<API.Clients.PersonaApi>();
builder.Services.AddScoped<API.Clients.InscripcionApi>();
builder.Services.AddScoped<API.Clients.CursoApi>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
