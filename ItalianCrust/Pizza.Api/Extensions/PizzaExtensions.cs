using Pizza.Api.DTOs;

namespace Pizza.Api.Extensions
{
    public static class PizzaExtensions
    {
        public static PizzaDTO ConvertToDTO(this Models.Pizza pizza)
        {
            return new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price
            };
        }

        public static void MapPizzaDTOToPizza(this Models.Pizza pizza, PizzaDTO pizzaDTO)
        {
            pizza.Name = pizzaDTO.Name;
            pizza.Description = pizzaDTO.Description;
            pizza.Price = pizzaDTO.Price;
        }

    }
}
