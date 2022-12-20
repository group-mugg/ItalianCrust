using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.Api.Endpoints;

public static class DeletePizzaEndpoint
{
    public static string Pattern { get => "/pizzas/{id}"; }
    public static Delegate Handler { get => (IPizzaRepository repo, int id) => DeletePizzaHandler.HandleAsync(repo, id); }
}
