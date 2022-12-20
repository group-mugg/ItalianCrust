using Order.Api.DTOs;

namespace Order.Api.Repositories;

public interface IPizzaRepository
{
    Task<bool> CreatePizza(PizzaDTO pizza);
    Task<IEnumerable<PizzaDTO>> GetAllPizzas();
    Task<PizzaDTO?> GetPizzaById(int id);
    Task<bool> EditPizza(PizzaDTO pizza);
    Task<bool> DeletePizza(int id);
}
