using Pizza.Api.Endpoints;

namespace Pizza.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        //Welcome!
        app.MapGet("/", () => "Welcome to the Pizza API of Italian Crust!");
        
        //Create
        app.MapPost(CreatePizzaEndpoint.Pattern, CreatePizzaEndpoint.Handler);

        //Read
        app.MapGet(GetAllPizzasEndpoint.Pattern, GetAllPizzasEndpoint.Handler);
        app.MapGet(GetPizzaByIdEndpoint.Pattern, GetPizzaByIdEndpoint.Handler);

        //Update
        app.MapPut(EditPizzaEndpoint.Pattern, EditPizzaEndpoint.Handler);

        //Delete
        app.MapDelete(DeletePizzaEndpoint.Pattern, DeletePizzaEndpoint.Handler);
    }
}
