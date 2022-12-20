using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.Api.Endpoints;

public static class GetOrderByIdEndpoint
{
    public static string Pattern { get => "/orders/{id}"; }
    public static Delegate Handler { get => (IOrderRepository repo, int id) => GetOrderByIdHandler.HandleAsync(repo, id); }
}
