using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class DeletePizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id)
    {
        var result = await repo.DeletePizza(id);
        return Results.Ok(result);
    }
}
