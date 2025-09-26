using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {
            app.MapGet("/materias/{id}", (int id) =>
            {
                var service = new MateriaService();

                var dto = service.Get(id);

                if (dto == null)
                    return Results.NotFound();

                return Results.Ok(dto);
            })
            .WithName("GetMateria")
            .Produces<MateriaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/materias", () =>
            {
                var service = new MateriaService();

                var dtos = service.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllMaterias")
            .Produces<List<MateriaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/materias", (MateriaDTO dto) =>
            {
                try
                {
                    var service = new MateriaService();

                    var materiaDTO = service.Add(dto);

                    // Ojo: propiedad según tu DTO (IDMateria).
                    return Results.Created($"/materias/{materiaDTO.IDMateria}", materiaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddMateria")
            .Produces<MateriaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/materias", (MateriaDTO dto) =>
            {
                try
                {
                    var service = new MateriaService();

                    var updated = service.Update(dto);

                    if (!updated)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateMateria")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/materias/{id}", (int id) =>
            {
                var service = new MateriaService();

                var deleted = service.Delete(id);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeleteMateria")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
