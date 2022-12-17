using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class GetAllPizzasHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo) => Results.Ok(await repo.GetAllPizzas());
}
