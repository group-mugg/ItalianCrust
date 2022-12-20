using Order.Api.DTOs;

namespace Order.Api.Repositories;

public class PizzaRepository : IPizzaRepository
{
    public Task<bool> CreatePizza(PizzaDTO pizza)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePizza(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EditPizza(PizzaDTO pizza)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PizzaDTO>> GetAllPizzas()
    {
        throw new NotImplementedException();
    }

    public Task<PizzaDTO?> GetPizzaById(int id)
    {
        throw new NotImplementedException();
    }
}
