using Order.Api.Repositories;
using Order.Api.Requests;

namespace Order.Api.Handlers;

public static class CreateOrderHandler
{
    public static async Task<IResult> HandleAsync(IOrderRepository repo, CreateOrderRequest request)
    {
        if (string.IsNullOrEmpty(request.Name) || request.PizzaIdQuantity.Count < 1) return Results.BadRequest(false);

        var response = await repo.CreateOrder(request);

        if (response == false) return Results.BadRequest(false);

        return Results.Ok(response);
    }
}
