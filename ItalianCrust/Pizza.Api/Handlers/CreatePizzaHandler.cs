using Microsoft.AspNetCore.Http.HttpResults;
using Pizza.Api.DTOs;
using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class CreatePizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, PizzaDTO pizza)
    {
        if(pizza.Price < 0)
        {
            return Results.BadRequest(false);
        }

        await repo.CreatePizza(pizza);
        return Results.Ok(true);
    }
}
