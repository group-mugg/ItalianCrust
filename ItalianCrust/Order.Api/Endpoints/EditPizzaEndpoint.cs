using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.Api.Endpoints;

public static class EditPizzaEndpoint
{
    public static string Pattern { get => "/pizzas"; }
    public static Delegate Handler { get => (IPizzaRepository repo, PizzaDTO pizza) => EditPizzaHandler.HandleAsync(repo, pizza); }
}
