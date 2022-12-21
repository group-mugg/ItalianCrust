using Order.Api.DTOs;
using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class CreatePizzaHandler
{
    public static async Task<IResult> HandleAsync(IPizzaRepository repo, PizzaDTO pizza)
    {
        throw new NotImplementedException();
    }
}
