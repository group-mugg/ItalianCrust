using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class GetPizzaByIdHandler
{
    public static async Task<IResult?> HandleAsync(IPizzaRepository repo, int id)
    {
        if (await repo.GetPizzaById(id) == null)
            return Results.NotFound();

        return Results.Ok(await repo.GetPizzaById(id));
    }
}
