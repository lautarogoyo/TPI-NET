using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this WebApplication app)
        {
            app.MapGet("/planes/{id}", (int id) =>
            {
                var service = new PlanService();
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetPlan")
            .Produces<PlanDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/planes", () =>
            {
                var service = new PlanService();
                return Results.Ok(service.GetAll());
            })
            .WithName("GetAllPlanes")
            .Produces<List<PlanDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/planes", (PlanDTO dto) =>
            {
                try
                {
                    var service = new PlanService();
                    var result = service.Add(dto);
                    return Results.Created($"/planes/{result.IDPlan}", result);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPlan")
            .Produces<PlanDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/planes", (PlanDTO dto) =>
            {
                try
                {
                    var service = new PlanService();
                    return service.Update(dto) ? Results.NoContent() : Results.NotFound();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePlan")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/planes/{id}", (int id) =>
            {
                PlanService planService = new PlanService();

                try
                {
                    var deleted = planService.Delete(id);

                    if (!deleted)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("DeletePlan")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
