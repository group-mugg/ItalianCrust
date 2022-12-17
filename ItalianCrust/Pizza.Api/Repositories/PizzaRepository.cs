using Microsoft.EntityFrameworkCore;
using Pizza.Api.DAL;

namespace Pizza.Api.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private readonly PizzaContext _context;

    public PizzaRepository(PizzaContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Models.Pizza>> GetAllPizzas()
    {
        return await _context.Pizzas.ToListAsync();
    }
    public async Task<Models.Pizza?> GetPizzaById(int id)
    {
        return await _context.Pizzas.FindAsync(id);
    }

    public async Task<bool> CreatePizza(Models.Pizza pizza)
    {
        await _context.Pizzas.AddAsync(pizza);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditPizza(Models.Pizza pizza)
    {
        var dbPizza = await _context.Pizzas.FindAsync(pizza.Id);

        if (dbPizza == null)
            return false;

        dbPizza.Name = pizza.Name;
        dbPizza.Description = pizza.Description;
        dbPizza.Price = pizza.Price;

        _context.Pizzas.Update(dbPizza);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePizza(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);

        if (pizza == null)
            return false;

        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();

        return true;
    }
}
