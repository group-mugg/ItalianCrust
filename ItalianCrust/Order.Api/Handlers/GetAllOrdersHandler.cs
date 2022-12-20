using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class GetAllOrdersHandler
{
    public static async Task<IResult> HandleAsync(IOrderRepository repo)
    {
        return Results.Ok(await repo.GetAllOrders());
    }
}
