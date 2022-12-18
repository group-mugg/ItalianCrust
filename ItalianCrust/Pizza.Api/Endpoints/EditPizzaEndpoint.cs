using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.Api.Endpoints;

public static class EditPizzaEndpoint
{
    public static string Pattern { get => "/pizzas"; }
    public static Delegate Handler { get => (IPizzaRepository pizzaRepository, Models.Pizza pizza) => EditPizzaHandler.HandleAsync(pizzaRepository, pizza); }
}
