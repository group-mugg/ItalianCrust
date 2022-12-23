using Order.Api.Handlers;
using Order.Api.Repositories;
using Order.Api.Requests;

namespace Order.Api.Endpoints;

public static class CreateOrderEndpoint
{
    public static string Pattern { get => "/orders"; }
    public static Delegate Handler { get => (IOrderRepository repo, CreateOrderRequest request) => CreateOrderHandler.HandleAsync(repo, request); }
}
