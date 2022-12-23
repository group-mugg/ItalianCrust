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
        app.MapPost(CreatePizzaEndpoint.Pattern, CreatePizzaEndpoint.Handler);

        //Read
        app.MapGet(GetAllOrdersEndpoint.Pattern, GetAllOrdersEndpoint.Handler);
        app.MapGet(GetOrderByIdEndpoint.Pattern, GetOrderByIdEndpoint.Handler);
        app.MapGet(GetAllPizzasEndpoint.Pattern, GetAllPizzasEndpoint.Handler);
        app.MapGet(GetPizzaByIdEndpoint.Pattern, GetPizzaByIdEndpoint.Handler);

        //Update
        app.MapPut(EditPizzaEndpoint.Pattern, EditPizzaEndpoint.Handler);

        //Delete
        app.MapDelete(DeleteOrderEndpoint.Pattern, DeleteOrderEndpoint.Handler);
        app.MapDelete(DeletePizzaEndpoint.Pattern, DeletePizzaEndpoint.Handler);
    }
}
