using Moq;
using Order.Api.DTOs;
using Order.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.UnitTests.MoqTests;

public class GetAllOrdersHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenThereAreOrdersInDatabase_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.GetAllOrders())
            .ReturnsAsync(new List<OrderDTO>
            {
                new OrderDTO { Id = 1, CustomerName = "Test"}
            });
    }
}
