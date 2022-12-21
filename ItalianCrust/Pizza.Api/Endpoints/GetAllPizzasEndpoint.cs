using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.Api.Endpoints;

public static class GetAllPizzasEndpoint
{
    public static string Pattern { get => "/pizzas"; }
    public static Delegate Handler { get => (IPizzaRepository pizzaRepository) => GetAllPizzasHandler.HandleAsync(pizzaRepository); }
}
