using Pizza.Api.DTOs;
using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class GetPizzaByIdHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id)
    {
        return Results.Ok(new PizzaDTO { Id = 1 });
    }
}