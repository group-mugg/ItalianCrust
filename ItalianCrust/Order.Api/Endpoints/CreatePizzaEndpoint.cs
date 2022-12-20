using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.Api.Endpoints;

public static class CreatePizzaEndpoint
{
    public static string Pattern { get => "/pizzas"; }
    public static Delegate Handler { get => (IPizzaRepository repo, PizzaDTO pizza) => CreatePizzaHandler.HandleAsync(repo, pizza); }
}
