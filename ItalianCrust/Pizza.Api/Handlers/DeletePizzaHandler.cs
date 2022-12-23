using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class DeletePizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id)
    {
        var result = await repo.DeletePizza(id);
        if (result)
        {
            return Results.Ok(result);
        }
        return Results.NotFound(result);
    }
}
