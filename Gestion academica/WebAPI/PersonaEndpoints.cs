using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PersonaEndpoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            // GET ALL
            app.MapGet("/personas", () =>
            {
                var service = new PersonaService();
                var personas = service.GetAll();
                return Results.Ok(personas);
            })
            .WithName("GetAllPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            // GET BY ID
            app.MapGet("/personas/{id}", (int id) =>
            {
                var service = new PersonaService();
                var persona = service.Get(id);

                return persona is not null
                    ? Results.Ok(persona)
                    : Results.NotFound();
            })
            .WithName("GetPersonaById")
            .Produces<PersonaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // POST (crear)
            app.MapPost("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    var service = new PersonaService();
                    var persona = service.Add(dto);
                    return Results.Created($"/personas/{persona.IDPersona}", persona);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPersona")
            .Produces<PersonaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // PUT (editar)
            app.MapPut("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    var service = new PersonaService();
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
            .WithName("UpdatePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            // DELETE
            app.MapDelete("/personas/{id}", (int id) =>
            {
                var service = new PersonaService();
                var deleted = service.Delete(id);

                if (!deleted)
                    return Results.NotFound();

                return Results.NoContent();
            })
            .WithName("DeletePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
