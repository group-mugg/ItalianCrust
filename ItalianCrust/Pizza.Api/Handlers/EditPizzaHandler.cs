using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class EditPizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, Models.Pizza pizza)
    {
        var result = await repo.EditPizza(pizza);
        return Results.Ok(result);
    }
}
