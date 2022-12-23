using Order.Api.Repositories;

namespace Order.Api.Handlers;

public static class GetOrderByIdHandler
{
    public static async Task<IResult> HandleAsync(IOrderRepository repo, int id)
    {
        if (await repo.GetOrderById(id) == null)
            return Results.NotFound();

        return Results.Ok(await repo.GetOrderById(id));
    }
}
