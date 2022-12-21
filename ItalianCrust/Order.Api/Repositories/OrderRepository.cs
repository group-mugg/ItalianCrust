using Order.Api.DTOs;
using Order.Api.Models;
using Order.Api.Requests;

namespace Order.Api.Repositories;

public class OrderRepository : IOrderRepository
{
    private ModelDbContext modelDbContext;

    public OrderRepository(ModelDbContext modelDbContext)
    {
        this.modelDbContext = modelDbContext;
    }

    public Task<bool> CreateOrder(CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDTO?> GetOrderById(int id)
    {
        throw new NotImplementedException();
    }
}
