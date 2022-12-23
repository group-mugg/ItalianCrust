using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class DeletePizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id)
    {
        var request = await repo.DeletePizza(id);

        if (request == false) return Results.NotFound(false);

        return Results.Ok(request);
    }
}
