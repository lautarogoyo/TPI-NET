using WebAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    // También por rol:
    // [Authorize(Roles="Profesor")] / [Authorize(Roles="Alumno")]
});

var app = builder.Build();


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
