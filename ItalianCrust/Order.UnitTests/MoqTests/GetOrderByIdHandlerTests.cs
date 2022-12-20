using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.UnitTests.MoqTests;

public class GetOrderByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenOrderDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.GetOrderById(It.Is<int>(id => id == 1)))
            .ReturnsAsync((OrderDTO?)null);

        //Act
        var notFoundResult = (NotFound)await GetOrderByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task HandleAsync_WhenOrderExists_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.GetOrderById(It.Is<int>(id => id == 1)))
            .ReturnsAsync(new OrderDTO
            {
                Id = 1
            });

        //Act
        var okResult = (Ok<OrderDTO>)await GetOrderByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundOrder = Assert.IsAssignableFrom<OrderDTO>(okResult.Value);
        Assert.Equal(1, foundOrder.Id);
    }
}
