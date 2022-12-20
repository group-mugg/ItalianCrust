using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.UnitTests.MoqTests;

public class DeleteOrderHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenDeletingExistingOrder_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.DeleteOrder(It.Is<int>(id => id == 1)))
            .ReturnsAsync(true);

        //Act
        var okResult = (Ok<bool>)await DeleteOrderHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        Assert.IsAssignableFrom<bool>(okResult.Value);
        Assert.True(okResult.Value);
    }

    [Fact]
    public async Task HandleAsync_WhenTryingToDeleteUnexistingOrder_ReturnsBadRequest()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.DeleteOrder(It.Is<int>(id => id == 1)))
            .ReturnsAsync(false);

        //Act
        var badRequestResult = (BadRequest<bool>)await DeleteOrderHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(400, badRequestResult.StatusCode);
        Assert.IsAssignableFrom<bool>(badRequestResult.Value);
        Assert.False(badRequestResult.Value);
    }
}
