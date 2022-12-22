using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class DeletePizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id)
    {
        if (await repo.DeletePizza(id) == false) return Results.NotFound(false);

        return Results.Ok(await repo.DeletePizza(id));
    }
}
