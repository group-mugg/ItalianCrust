using Order.Api.DTOs;

namespace Order.Api.Extensions;

public static class PizzaExtensions
{
    public static PizzaDTO ConvertToDTO(this Models.Pizza pizza)
    {
        return new PizzaDTO
        {
            Id = pizza.Id,
            Name = pizza.Name,
            Price = pizza.Price
        };
    }
}
