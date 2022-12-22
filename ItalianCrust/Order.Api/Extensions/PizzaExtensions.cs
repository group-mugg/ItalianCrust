using Order.Api.DTOs;

namespace Order.Api.Extensions
{
    public static class PizzaExtensions
    {
        public static PizzaDTO ConvertToDTO(this Models.Pizza pizza)
        {
            var pizzaDto = new PizzaDTO();
            pizzaDto.Id = pizza.Id;
            pizzaDto.Name = pizza.Name;
            pizzaDto.Price = pizza.Price;

            return pizzaDto;
        }
    }
}
