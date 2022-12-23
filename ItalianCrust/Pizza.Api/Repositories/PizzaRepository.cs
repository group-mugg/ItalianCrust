using Microsoft.EntityFrameworkCore;
using Pizza.Api.DAL;
using Pizza.Api.DTOs;
using Pizza.Api.Extensions;

namespace Pizza.Api.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private readonly PizzaContext _context;

    public PizzaRepository(PizzaContext context)
    {
        _context = context;
    }

    public async Task<bool> CreatePizza(PizzaDTO pizzaDTO)
    {
        Models.Pizza pizza = new Models.Pizza();
        pizza.MapPizzaDTOToPizza(pizzaDTO);

        await _context.Pizzas.AddAsync(pizza);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePizza(int id)
    {
        var dBPizza = await _context.Pizzas.FindAsync(id);
        if (dBPizza is null)
        {
            return false;
        }

        _context.Remove(dBPizza);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditPizza(PizzaDTO pizza)
    {
        var dBPizza = await _context.Pizzas.FindAsync(pizza.Id);
        if (dBPizza is null)
        {
            return false;
        }

        dBPizza.MapPizzaDTOToPizza(pizza);
        _context.Update(dBPizza);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<PizzaDTO>> GetAllPizzas()
    {
        var pizzas = await _context.Pizzas.ToListAsync();

        List<PizzaDTO> pizzaDTOs = new List<PizzaDTO>();

        if(pizzas is not null)
        {
            foreach (var pizza in pizzas)
            {
                pizzaDTOs.Add(pizza.ConvertToDTO());
            }
        }
        
        return pizzaDTOs;
    }

    public async Task<PizzaDTO?> GetPizzaById(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);

        if (pizza is null)
        {
            return null;
        }

        PizzaDTO pizzaDTO = pizza.ConvertToDTO();

        return pizzaDTO;

    }
}
