using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ModuloUsuarioEndpoints
    {
        public static void MapModuloUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/modulosusuario/{id}", (int id) =>
            {
                var service = new ModuloUsuarioService();
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetModuloUsuario")
            .Produces<ModuloUsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/modulosusuario", () =>
            {
                var service = new ModuloUsuarioService();
                return Results.Ok(service.GetAll());
            })
            .WithName("GetAllModulosUsuario")
            .Produces<List<ModuloUsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/modulosusuario", (ModuloUsuarioDTO dto) =>
            {
                try
                {
                    var service = new ModuloUsuarioService();
                    var result = service.Add(dto);
                    return Results.Created($"/modulosusuario/{result.IDModuloUsuario}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddModuloUsuario")
            .Produces<ModuloUsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/modulosusuario", (ModuloUsuarioDTO dto) =>
            {
                try
                {
                    var service = new ModuloUsuarioService();
                    return service.Update(dto) ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateModuloUsuario")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/modulosusuario/{id}", (int id) =>
            {
                var service = new ModuloUsuarioService();
                return service.Delete(id) ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteModuloUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
