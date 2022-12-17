using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class CreatePizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, Models.Pizza pizza)
    {
        bool result = await repo.CreatePizza(pizza);
        return Results.Ok(result);
    }
}
