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
            .Produces<List<DocenteCursoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            // === GET BY IDs ===
            app.MapGet("/docentescursos/{idDocenteCurso}", (int idDocenteCurso) =>
            {
                var service = new DocenteCursoService();
                var dto = service.Get(idDocenteCurso);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            })
            .WithName("GetDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // === POST ===
            app.MapPost("/docentescursos", (DocenteCursoDTO dto) =>
            {
                var service = new DocenteCursoService();
                service.Add(dto);
                return Results.Created($"/docentescursos/{dto.IdDocenteCurso}", dto);
            })
            .WithName("AddDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            // === PUT ===
            app.MapPut("/docentescursos", (DocenteCursoDTO dto) =>
            {
                var service = new DocenteCursoService();
                bool updated = service.Update(dto);
                return updated ? Results.Ok(dto) : Results.NotFound();
            })
            .WithName("UpdateDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // === DELETE ===
            app.MapDelete("/docentescursos/{idDocenteCurso}", (int idDocenteCurso) =>
            {
                var service = new DocenteCursoService();
                bool deleted = service.Delete(idDocenteCurso);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteDocenteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
