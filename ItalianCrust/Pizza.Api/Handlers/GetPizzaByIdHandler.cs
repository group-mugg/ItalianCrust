using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class GetPizzaByIdHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id) => Results.Ok(await repo.GetPizzaById(id));
}
