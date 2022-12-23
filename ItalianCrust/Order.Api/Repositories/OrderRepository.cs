using Microsoft.EntityFrameworkCore;
using Order.Api.DTOs;
using Order.Api.Extensions;
using Order.Api.Models;
using Order.Api.Requests;

namespace Order.Api.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ModelDbContext _dBContext;

    public OrderRepository(ModelDbContext dBContextObject)
    {
        _dBContext = dBContextObject;
    }

    public async Task<bool> CreateOrder(CreateOrderRequest request)
    {
        Models.Order addOrder = new()
        {
            OrderDate = DateTime.Now,
            CustomerName = request.Name,
            OrderRows = (ICollection<OrderRow>)request.PizzaIdQuantity
        };

        var pizzaIdFound = false;

        // Check if pizza exists
        foreach (var pizzaInOrder in request.PizzaIdQuantity)
        {
            var pizzaId = pizzaInOrder.Key;

            foreach (var pizza in _dBContext.Pizzas)
            {
                if (pizzaId == pizza.Id)
                    pizzaIdFound = true;
            }
        }

        if (!pizzaIdFound)
        {
            return false;
        }

        await _dBContext.Orders.AddAsync(addOrder);
        await _dBContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var orderIsStored = false;
        foreach (var storedOrder in _dBContext.Orders) if (storedOrder.Id == id) orderIsStored = true;

        if (!orderIsStored) return false;

        _dBContext.Remove(_dBContext.Orders.FirstOrDefault(o => o.Id == id)!);

        await _dBContext.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        var orders = await _dBContext.Orders.ToListAsync();

        var orderDtos = new List<OrderDTO>();

        foreach (var order in orders)
        {
            var orderDto = order.ConvertToDTO();
            orderDtos.Add(orderDto);
        }

        return orderDtos;
    }

    public async Task<OrderDTO?> GetOrderById(int id)
    {
        var order = await _dBContext.Orders.FirstOrDefaultAsync(p => p.Id == id);

        if (order == null) return null;

        OrderDTO orderToReturn = order.ConvertToDTO();

        return orderToReturn;
    }
}
