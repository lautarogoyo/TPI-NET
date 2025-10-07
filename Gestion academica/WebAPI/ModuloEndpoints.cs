using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ModuloEndpoints
    {
        public static void MapModuloEndpoints(this WebApplication app)
        {
            app.MapGet("/modulos/{id}", (int id) =>
            {
                var service = new ModuloService();
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetModulo")
            .Produces<ModuloDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/modulos", () =>
            {
                var service = new ModuloService();
                return Results.Ok(service.GetAll());
            })
            .WithName("GetAllModulos")
            .Produces<List<ModuloDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/modulos", (ModuloDTO dto) =>
            {
                try
                {
                    var service = new ModuloService();
                    var result = service.Add(dto);
                    return Results.Created($"/modulos/{result.IDModulo}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddModulo")
            .Produces<ModuloDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/modulos", (ModuloDTO dto) =>
            {
                try
                {
                    var service = new ModuloService();
                    return service.Update(dto) ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateModulo")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/modulos/{id}", (int id) =>
            {
                var service = new ModuloService();
                return service.Delete(id) ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteModulo")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
