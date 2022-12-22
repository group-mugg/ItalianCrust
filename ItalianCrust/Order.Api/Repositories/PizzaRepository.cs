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

    public async Task<bool> DeletePizza(int id)
    {
        var pizzaIsStored = false;
        foreach (var storedPizza in _dBContext.Pizzas) if (storedPizza.Id == id) pizzaIsStored = true;

        if (!pizzaIsStored) return false;

        _dBContext.Remove(_dBContext.Pizzas.FirstOrDefault(p => p.Id == id)!);

        await _dBContext.SaveChangesAsync();

        return true;
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

    public async Task<PizzaDTO?> GetPizzaById(int id)
    {
        //var pizzaIsStored = false;
        //foreach (var storedPizza in _dBContext.Pizzas) if (storedPizza.Id == id) pizzaIsStored = true;

        //if (!pizzaIsStored) return (Task<PizzaDTO?>)Results.NotFound(false);

        var pizza = await _dBContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

        if (pizza == null) return null;

        PizzaDTO pizzaToReturn = pizza.ConvertToDTO();

        return pizzaToReturn;
    }
}