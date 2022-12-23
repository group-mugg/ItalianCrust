using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class GetAllPizzasHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo)
    {
        var pizzas = await repo.GetAllPizzas();

        return Results.Ok(pizzas);

    }
}
