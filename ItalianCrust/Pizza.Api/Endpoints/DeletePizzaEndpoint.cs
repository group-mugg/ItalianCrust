using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.Api.Endpoints;

public class DeletePizzaEndpoint
{
    public static string Pattern { get => "/pizzas/{pizzaId}"; }
    public static Delegate Handler { get => (IPizzaRepository pizzaRepository, int pizzaId) => DeletePizzaHandler.HandleAsync(pizzaRepository, pizzaId); }
}
