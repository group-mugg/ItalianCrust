using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.Api.Endpoints;

public static class GetPizzaByIdEndpoint
{
    public static string Pattern { get => "/pizzas/{pizzaId}"; }
    public static Delegate Handler { get => (IPizzaRepository pizzaRepository, int pizzaId) => GetPizzaByIdHandler.HandleAsync(pizzaRepository, pizzaId); }
}
