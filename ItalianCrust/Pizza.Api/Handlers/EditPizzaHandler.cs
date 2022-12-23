using Pizza.Api.DTOs;
using Pizza.Api.Repositories;

namespace Pizza.Api.Handlers;

public static class EditPizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, PizzaDTO pizza)
    {
        if (pizza.Price < 0)
        {
            return Results.BadRequest(false);
        }

        var response = await repo.EditPizza(pizza);
        return response ? Results.Ok(response) : Results.NotFound(response);
    }
}
