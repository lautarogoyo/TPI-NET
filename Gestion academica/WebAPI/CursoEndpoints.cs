using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/cursos/{id}", (int id) =>
            {
                var cursoService = new CursoService();

                var dto = cursoService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetCurso")
            .Produces<CursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/cursos", () =>
            {
                var cursoService = new CursoService();

                var dtos = cursoService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllCursos")
            .Produces<List<CursoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/cursos", (CursoDTO dto) =>
            {
                try
                {
                    var cursoService = new CursoService();

                    var cursoDTO = cursoService.Add(dto);

                    return Results.Created($"/cursos/{cursoDTO.IdCurso}", cursoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCurso")
            .Produces<CursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/cursos", (CursoDTO dto) =>
            {
                try
                {
                    var cursoService = new CursoService();

                    var updated = cursoService.Update(dto);

                    if (!updated)
                    {
                        return Results.NotFound();
                    }

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateCurso")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/cursos/{id}", (int id) =>
            {
                var cursoService = new CursoService();

                var deleted = cursoService.Delete(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/cursos/comisionmateria", () =>
            {
                var cursoService = new CursoService();
                var dtos = cursoService.GetWithComisionMateria();
                return Results.Ok(dtos);
            })
            .WithName("GetWithComisionMateria")
            .Produces<List<CursoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
