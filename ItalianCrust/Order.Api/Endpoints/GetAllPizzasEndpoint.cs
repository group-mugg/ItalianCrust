using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.Api.Endpoints;

public static class GetAllPizzasEndpoint
{
    public static string Pattern { get => "/pizzas"; }
    public static Delegate Handler { get => (IPizzaRepository repo) => GetAllPizzasHandler.HandleAsync(repo); }
}
