using Order.Api.DTOs;

namespace Order.Api.Extensions;

public static class OrderExtensions
{
    public static OrderDTO ConvertToDTO(this Models.Order order)
    {
        return new OrderDTO
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            OrderDate = order.OrderDate
        };
    }
}
