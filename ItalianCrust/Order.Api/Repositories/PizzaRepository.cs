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
        var dbPizza = await _dBContext.Pizzas.FindAsync(id);
        
        if (dbPizza == null)
            return false;

        _dBContext.Pizzas.Remove(dbPizza);
        await _dBContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> EditPizza(PizzaDTO pizza)
    {
        var storedPizza = await _dBContext.Pizzas.FirstOrDefaultAsync(p => p.Id == pizza.Id);

        if (storedPizza == null)
            return false;

        storedPizza.Name = pizza.Name;
        storedPizza.Price = pizza.Price;

        _dBContext.Pizzas.Update(storedPizza);

        await _dBContext.SaveChangesAsync();
        return true;
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
        var pizza = await _dBContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

        if (pizza == null) return null;

        PizzaDTO pizzaToReturn = pizza.ConvertToDTO();

        return pizzaToReturn;
    }
}