using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class DeleteOrderHandler
{
    public static async Task<IResult> HandleAsync(IOrderRepository repo, int id)
    {
        var request = await repo.DeleteOrder(id);

        if (request == false) return Results.NotFound(false);

        return Results.Ok(request);
    }
}
