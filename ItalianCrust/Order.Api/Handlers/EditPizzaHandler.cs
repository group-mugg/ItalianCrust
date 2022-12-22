using Order.Api.DTOs;
using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class EditPizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, PizzaDTO pizza)
    {
        if (pizza.Price < 0 || string.IsNullOrEmpty(pizza.Name))
        {
            return Results.BadRequest(false);
        }

        var response = await repo.EditPizza(pizza);
        return Results.Ok(response);
    }
}
