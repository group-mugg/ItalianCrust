using Microsoft.EntityFrameworkCore;
using Pizza.Api.DAL;
using Pizza.Api.DTOs;

namespace Pizza.Api.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private readonly PizzaContext _context;

    public PizzaRepository(PizzaContext context)
    {
        _context = context;
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
