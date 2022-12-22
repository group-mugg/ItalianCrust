using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class GetAllPizzasHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo)
    {
        return Results.Ok(await repo.GetAllPizzas());
    }
}
