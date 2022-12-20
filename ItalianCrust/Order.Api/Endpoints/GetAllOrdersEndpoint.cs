using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.Api.Endpoints;

public static class GetAllOrdersEndpoint
{
    public static string Pattern { get => "/orders"; }
    public static Delegate Handler { get => (IOrderRepository repo) => GetAllOrdersHandler.HandleAsync(repo); }
}
