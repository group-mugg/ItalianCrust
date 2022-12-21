using Order.Api.DTOs;

namespace Order.Api.Repositories;
using Microsoft.EntityFrameworkCore;


public class PizzaRepository : IPizzaRepository
{

    private ModelDbContext _dBContext;

    public OrderRepository(ModelDbContext dBContextObject)
    {
        _dBContext = dBContextObject;
    }

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
