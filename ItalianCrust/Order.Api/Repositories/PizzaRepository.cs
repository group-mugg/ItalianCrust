using Order.Api.DTOs;

namespace Order.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Order.Api.Extensions;
using Order.Api.Models;

public class PizzaRepository : IPizzaRepository
{

    private ModelDbContext _dBContext;

    public PizzaRepository(ModelDbContext dBContextObject)
    {
        _dBContext = dBContextObject;
    }

    public async Task<bool> CreatePizza(PizzaDTO pizza)
    {
        Models.Pizza addPizza = new Pizza();
        addPizza.Name = pizza.Name;
        addPizza.Price = pizza.Price;
        await _dBContext.Pizzas.AddAsync(addPizza);

        await _dBContext.SaveChangesAsync();
        return true;
    }

    public Task<bool> DeletePizza(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EditPizza(PizzaDTO pizza)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PizzaDTO>> GetAllPizzas()
    {
        var pizzas = await _dBContext.Pizzas.ToListAsync();

        var pizzaDtos = new List<PizzaDTO>();

        foreach (var pizza in pizzas)
        {
            var pizzaDto = pizza.ConvertToDTO();
            pizzaDtos.Add(pizzaDto);
        }

        return pizzaDtos;
    }

    public Task<PizzaDTO?> GetPizzaById(int id)
    {
        throw new NotImplementedException();
    }
}
