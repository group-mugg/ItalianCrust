using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.Api.Endpoints;

public static class GetPizzaByIdEndpoint
{
    public static string Pattern { get => "/pizzas/{id}"; }
    public static Delegate Handler { get => (IPizzaRepository repo, int id) => GetPizzaByIdHandler.HandleAsync(repo, id); }
}
