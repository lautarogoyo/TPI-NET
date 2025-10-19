using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class DocenteCursoEndpoints
    {
        public static void MapDocenteCursoEndpoints(this WebApplication app)
        {
            // === GET ALL ===
            app.MapGet("/docentescursos", () =>
            {
                var service = new DocenteCursoService();
                var dtos = service.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllDocentesCursos")
            .Produces<List<DocenteCurso>>(StatusCodes.Status200OK)
            .WithOpenApi();

            // === GET BY IDs ===
            app.MapGet("/docentescursos/{idCurso}/{idDocente}", (int idCurso, int idDocente) =>
            {
                var service = new DocenteCursoService();
                var dto = service.Get(idCurso, idDocente);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            })
            .WithName("GetDocenteCurso")
            .Produces<DocenteCurso>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // === POST ===
            app.MapPost("/docentescursos", (DocenteCurso dto) =>
            {
                var service = new DocenteCursoService();
                service.Add(dto);
                return Results.Created($"/docentescursos/{dto.IDCurso}/{dto.IDDocente}", dto);
            })
            .WithName("AddDocenteCurso")
            .Produces<DocenteCurso>(StatusCodes.Status201Created)
            .WithOpenApi();

            // === PUT ===
            app.MapPut("/docentescursos", (DocenteCurso dto) =>
            {
                var service = new DocenteCursoService();
                bool updated = service.Update(dto);
                return updated ? Results.Ok(dto) : Results.NotFound();
            })
            .WithName("UpdateDocenteCurso")
            .Produces<DocenteCurso>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // === DELETE ===
            app.MapDelete("/docentescursos/{idCurso}/{idDocente}", (int idCurso, int idDocente) =>
            {
                var service = new DocenteCursoService();
                bool deleted = service.Delete(idCurso, idDocente);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteDocenteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
