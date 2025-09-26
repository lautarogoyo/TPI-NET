using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ComisionEndpoints
    {
        public static void MapComisionEndpoints(this WebApplication app)
        {
            app.MapGet("/comisiones/{id}", (int id) =>
            {
                var service = new ComisionService();

                var dto = service.Get(id);

                if (dto == null)
                    return Results.NotFound();

                return Results.Ok(dto);
            })
            .WithName("GetComision")
            .Produces<ComisionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/comisiones", () =>
            {
                var service = new ComisionService();

                var dtos = service.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllComisiones")
            .Produces<List<ComisionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/comisiones", (ComisionDTO dto) =>
            {
                try
                {
                    var service = new ComisionService();

                    var comisionDTO = service.Add(dto);

                    // Ojo: propiedad según tu DTO (IDComision).
                    return Results.Created($"/comisiones/{comisionDTO.IDComision}", comisionDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddComision")
            .Produces<ComisionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/comisiones", (ComisionDTO dto) =>
            {
                try
                {
                    var service = new ComisionService();

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
            .WithName("UpdateComision")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/comisiones/{id}", (int id) =>
            {
                var service = new ComisionService();

                var deleted = service.Delete(id);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeleteComision")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
