using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

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
                new OrderDTO { Id = 1 },
                new OrderDTO { Id = 2 },
                new OrderDTO { Id = 3 }
            });

        //Act
        var okResult = (Ok<IEnumerable<OrderDTO>>)await GetAllOrdersHandler.HandleAsync(mock.Object);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundOrders = Assert.IsAssignableFrom<IEnumerable<OrderDTO>>(okResult.Value);

        Assert.NotEmpty(foundOrders);
        Assert.Collection(foundOrders, order1 =>
        {
            Assert.Equal(1, order1.Id);
        }, order2 =>
        {
            Assert.Equal(2, order2.Id);
        }, order3 =>
        {
            Assert.Equal(3, order3.Id);
        });
    }
}
