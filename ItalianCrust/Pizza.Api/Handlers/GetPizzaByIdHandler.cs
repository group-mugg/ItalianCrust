using Microsoft.AspNetCore.Mvc;
using Pizza.Api.DTOs;
using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class GetPizzaByIdHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id)
    {
        var pizza = await repo.GetPizzaById(id);

        if(pizza is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(pizza);

    }
}