using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class AlumnoInscripcionEndpoints
    {
        public static void MapAlumnoInscripcionEndpoints(this WebApplication app)
        {
            app.MapGet("/alumnoinscripciones/{id}", (int id) =>
            {
                var service = new AlumnoInscripcionService();
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetAlumnoInscripcion")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/alumnoinscripciones", () =>
            {
                var service = new AlumnoInscripcionService();
                return Results.Ok(service.GetAll());
            })
            .WithName("GetAllAlumnoInscripciones")
            .Produces<List<AlumnoInscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/alumnoinscripciones", (AlumnoInscripcionDTO dto) =>
            {
                try
                {
                    var service = new AlumnoInscripcionService();
                    var result = service.Add(dto);
                    return Results.Created($"/alumnoinscripciones/{result.IDInscripcion}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAlumnoInscripcion")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/alumnoinscripciones", (AlumnoInscripcionDTO dto) =>
            {
                try
                {
                    var service = new AlumnoInscripcionService();
                    return service.Update(dto) ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateAlumnoInscripcion")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/alumnoinscripciones/{id}", (int id) =>
            {
                var service = new AlumnoInscripcionService();
                return service.Delete(id) ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteAlumnoInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
