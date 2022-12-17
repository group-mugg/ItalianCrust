using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        //Welcome!
        app.MapGet("/", () => "Welcome to Italian Crust!");
        
        //Create
        app.MapPost("/pizzas", (IPizzaRepository pizzaRepository, Models.Pizza pizza) => CreatePizzaHandler.HandleAsync(pizzaRepository, pizza));

        //Read
        app.MapGet("/pizzas", (IPizzaRepository pizzaRepository) => GetAllPizzasHandler.HandleAsync(pizzaRepository));
        app.MapGet("/pizzas/{pizzaId}", (IPizzaRepository pizzaRepository, int pizzaId) => GetPizzaByIdHandler.HandleAsync(pizzaRepository, pizzaId));

        //Update
        app.MapPut("/pizzas", (IPizzaRepository pizzaRepository, Models.Pizza pizza) => EditPizzaHandler.HandleAsync(pizzaRepository, pizza));

        //Delete
        app.MapDelete("/pizzas/{pizzaId}", (IPizzaRepository pizzaRepository, int pizzaId) => DeletePizzaHandler.HandleAsync(pizzaRepository, pizzaId));
    }
}
