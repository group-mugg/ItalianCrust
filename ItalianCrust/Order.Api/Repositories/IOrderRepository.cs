using Order.Api.DTOs;
using Order.Api.Requests;

namespace Order.Api.Repositories;

public interface IOrderRepository
{
    Task<bool> CreateOrder(CreateOrderRequest request);
    Task<IEnumerable<OrderDTO>> GetAllOrders();
    Task<OrderDTO?> GetOrderById(int id);
    Task<bool> DeleteOrder(int id);
}
