using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ComisionMateriaEndpoints
    {
        public static void MapComisionMateriaEndpoints(this WebApplication app)
        {
            app.MapGet("/comisionesmaterias/{id}", (int id) =>
            {
                var service = new ComisionMateriaService();
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetComisionMateria")
            .Produces<ComisionMateriaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/comisionesmaterias", () =>
            {
                var service = new ComisionMateriaService();
                return Results.Ok(service.GetAll());
            })
            .WithName("GetAllComisionesMaterias")
            .Produces<List<ComisionMateriaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/comisionesmaterias", (ComisionMateriaDTO dto) =>
            {
                try
                {
                    var service = new ComisionMateriaService();
                    var result = service.Add(dto);
                    return Results.Created($"/comisionesmaterias/{result.IDComisionMateria}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddComisionMateria")
            .Produces<ComisionMateriaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/comisionesmaterias", (ComisionMateriaDTO dto) =>
            {
                try
                {
                    var service = new ComisionMateriaService();
                    return service.Update(dto) ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateComisionMateria")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/comisionesmaterias/{id}", (int id) =>
            {
                ComisionMateriaService comisionMateriaService = new ComisionMateriaService();

                try
                {
                    var deleted = comisionMateriaService.Delete(id);

                    if (!deleted)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("DeleteComisionMateria")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
