using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class InscripcionEndpoints
    {
        public static void MapInscripcionEndpoints(this WebApplication app)
        {
            app.MapGet("/inscripciones/{idCurso}/{idAlumno}", (int idCurso, int idAlumno) =>
            {
                var service = new InscripcionService();
                var dto = service.Get(idCurso, idAlumno);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetInscripcion")
            .Produces<InscripcionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/inscripciones", () =>
            {
                var service = new InscripcionService();
                return Results.Ok(service.GetAll());
            })
            .WithName("GetAllInscripciones")
            .Produces<List<InscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/inscripciones", (InscripcionDTO dto) =>
            {
                try
                {
                    var service = new InscripcionService();
                    var result = service.Add(dto);
                    return Results.Created($"/inscripciones/{result.IDInscripcion}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddInscripcion")
            .Produces<InscripcionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/inscripciones", (InscripcionDTO dto) =>
            {
                try
                {
                    var service = new InscripcionService();
                    return service.Update(dto) ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateInscripcion")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/inscripciones/{id}", (int id) =>
            {
                var service = new InscripcionService();
                return service.Delete(id) ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/inscripciones/usuario/{idAlumno}", (int idAlumno) =>
            {
                var service = new InscripcionService();
                return Results.Ok(service.GetByAlumno(idAlumno));
            })
            .WithName("GetByAlumno")
            .Produces<List<InscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/inscripciones/curso/{idCurso}", (int idCurso) =>
            {
                var service = new InscripcionService();
                return Results.Ok(service.CuantosInscriptos(idCurso));
            })
            .WithName("GetCuantosInscriptos")
            .Produces<int>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/inscripciones/alumnos/{idCurso}", (int idCurso) =>
            {
                var service = new InscripcionService();
                return Results.Ok(service.GetByCurso(idCurso));
            })
            .WithName("GetInscripcionesAlumnos")
            .Produces<List<InscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
