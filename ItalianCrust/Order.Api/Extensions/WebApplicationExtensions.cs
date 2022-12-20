using Order.Api.Endpoints;

namespace Order.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        //Welcome!
        app.MapGet("/", () => "Welcome to the Order API of Italian Crust!");

        //Create
        app.MapPost(CreateOrderEndpoint.Pattern, CreateOrderEndpoint.Handler);

        //Read
        app.MapGet(GetAllOrdersEndpoint.Pattern, GetAllOrdersEndpoint.Handler);
        app.MapGet(GetOrderByIdEndpoint.Pattern, GetOrderByIdEndpoint.Handler);

        //Delete
        app.MapDelete(DeleteOrderEndpoint.Pattern, DeleteOrderEndpoint.Handler);
    }
}
