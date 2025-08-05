using Domain.Services;
using Domain.Model;
using DTOs;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// 🔹 GET by IDDocente + IDCurso
app.MapGet("/docentes-curso/{idDocente}/{idCurso}", (int idDocente, int idCurso) =>
{
    DocenteCursoService service = new DocenteCursoService();
    var docenteCurso = service.Get(idDocente, idCurso);

    if (docenteCurso == null)
        return Results.NotFound();

    var dto = new DTOs.DocenteCurso
    {
        Cargo = (DTOs.TiposCargos)docenteCurso.Cargo,
        IDCurso = docenteCurso.IDCurso,
        IDDocente = docenteCurso.IDDocente
    };

    return Results.Ok(dto);
})
.WithName("GetDocenteCurso")
.Produces<DTOs.DocenteCurso>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

// 🔹 GET All
app.MapGet("/docentes-curso", () =>
{
    DocenteCursoService service = new DocenteCursoService();
    var lista = service.GetAll();

    var dtos = lista.Select(dc => new DTOs.DocenteCurso
    {
        Cargo = (DTOs.TiposCargos)dc.Cargo,
        IDCurso = dc.IDCurso,
        IDDocente = dc.IDDocente
    }).ToList();

    return Results.Ok(dtos);
})
.WithName("GetAllDocentesCurso")
.Produces<List<DTOs.DocenteCurso>>(StatusCodes.Status200OK)
.WithOpenApi();

// 🔹 POST
app.MapPost("/docentes-curso", (DTOs.DocenteCurso dto) =>
{
    try
    {
        DocenteCursoService service = new DocenteCursoService();

        var model = new Domain.Model.DocenteCurso(
            (Domain.Model.TiposCargos)dto.Cargo,
            dto.IDCurso,
            dto.IDDocente
        );

        service.Add(model);

        return Results.Created(
            $"/docentes-curso/{dto.IDDocente}/{dto.IDCurso}",
            dto
        );
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddDocenteCurso")
.Produces<DTOs.DocenteCurso>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

// 🔹 PUT
app.MapPut("/docentes-curso", (DTOs.DocenteCurso dto) =>
{
    try
    {
        DocenteCursoService service = new DocenteCursoService();

        var model = new Domain.Model.DocenteCurso(
            (Domain.Model.TiposCargos)dto.Cargo,
            dto.IDCurso,
            dto.IDDocente
        );

        var updated = service.Update(model);

        return updated ? Results.NoContent() : Results.NotFound();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("UpdateDocenteCurso")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

// 🔹 DELETE
app.MapDelete("/docentes-curso/{idDocente}/{idCurso}", (int idDocente, int idCurso) =>
{
    DocenteCursoService service = new DocenteCursoService();

    var deleted = service.Delete(idDocente, idCurso);

    return deleted ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteDocenteCurso")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();


app.MapGet("/especialidades/{idEspecialidad}", (int idEspecialidad) =>
{
    EspecialidadService service = new EspecialidadService();
    var especialidad = service.Get(idEspecialidad);

    if (especialidad == null)
        return Results.NotFound();

    var dto = new DTOs.Especialidad
    {
        IDEspecialidad = especialidad.IDEspecialidad,
        Descripcion = especialidad.Descripcion,
    };

    return Results.Ok(dto);
})
.WithName("GetEspecialidad")
.Produces<DTOs.Especialidad>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

// 🔹 GET All
app.MapGet("/especialidades", () =>
{
    EspecialidadService service = new EspecialidadService();
    var lista = service.GetAll();

    var dtos = lista.Select(e => new DTOs.Especialidad
    {
        IDEspecialidad = e.IDEspecialidad,
        Descripcion = e.Descripcion
    }).ToList();

    return Results.Ok(dtos);
})
.WithName("GetAllEspecialidades")
.Produces<List<DTOs.Especialidad>>(StatusCodes.Status200OK)
.WithOpenApi();

// 🔹 POST
app.MapPost("/especialidades", (DTOs.Especialidad dto) =>
{
    try
    {
        EspecialidadService service = new EspecialidadService();

        var model = new Domain.Model.Especialidad(
            dto.IDEspecialidad,
            dto.Descripcion
        );

        service.Add(model);

        return Results.Created(
            $"/especialidades/{dto.IDEspecialidad}",
            dto
        );
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("AddEspecialidad")
.Produces<DTOs.Especialidad>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

// 🔹 PUT
app.MapPut("/especialidades", (DTOs.Especialidad dto) =>
{
    try
    {
        EspecialidadService service = new EspecialidadService();

        var model = new Domain.Model.Especialidad(
            dto.IDEspecialidad,
            dto.Descripcion
        );

        var updated = service.Update(model);

        return updated ? Results.NoContent() : Results.NotFound();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("UpdateEspecialidad")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

// 🔹 DELETE
app.MapDelete("/especialidades/{idEspecialidad}", (int idEspecialidad) =>
{
    EspecialidadService service = new EspecialidadService();

    var deleted = service.Delete(idEspecialidad);

    return deleted ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteEspecialidad")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.Run();