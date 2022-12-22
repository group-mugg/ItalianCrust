using Order.Api.DTOs;
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
        var order = _dBContext.Orders.FirstOrDefault(o => o.Id == id);

        //return (IResult)order;
        throw new NotImplementedException();
    }
}
