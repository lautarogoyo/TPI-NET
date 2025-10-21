using WebAPI;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// === Registrar DbContext (para EF) ===
builder.Services.AddDbContext<TPIContext>();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

// Add CORS for Blazor WebAssembly
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        policy =>
        {
            policy.WithOrigins("https://localhost:7170", "http://localhost:5076")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Configuración JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EsAdmin", p => p.RequireClaim("tipoPersona", "3"));
    options.AddPolicy("EsProfesor", p => p.RequireClaim("tipoPersona", "2"));
    options.AddPolicy("EsAlumno", p => p.RequireClaim("tipoPersona", "1"));
});

// === Crear la app ===
var app = builder.Build();

// === Crear la base de datos si no existe ===
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TPIContext>();
    db.Database.EnsureCreated();  
    Console.WriteLine("✅ Base de datos verificada o creada correctamente.");
}

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowBlazorWasm");

// Map endpoints
app.MapEspecialidadEndpoints();
app.MapPlanEndpoints();
app.MapComisionEndpoints();
app.MapMateriaEndpoints();
app.MapComisionMateriaEndpoints();
app.MapCursoEndpoints();
app.MapUsuarioEndpoints();
app.MapPersonaEndpoints();
app.MapInscripcionEndpoints();
app.MapModuloEndpoints();
app.MapModuloUsuarioEndpoints();
app.MapAuthEndpoints();
app.MapDocenteCursoEndpoints();

app.Run();
