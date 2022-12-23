using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Pizza.Api.DTOs;
using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.UnitTests.MoqTests;

public class DeletePizzaHandlerTests
{

    [Fact]
    public async Task HandleAsync_WhenPizzaDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.DeletePizza(It.Is<int>(id => id == 1)))
            .ReturnsAsync(false);

        //Act
        var notFoundResult = (NotFound<bool>)await DeletePizzaHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
        var returnedBool = Assert.IsAssignableFrom<bool>(notFoundResult.Value);
        Assert.False(returnedBool);
    }

    [Fact]
    public async Task HandleAsync_WhenPizzaExists_DeletesPizza()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.DeletePizza(It.Is<int>(id => id == 1)))
            .ReturnsAsync(true);

        //Act
        var okResult = (Ok<bool>)await DeletePizzaHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var returnedBool = Assert.IsAssignableFrom<bool>(okResult.Value);
        Assert.True(returnedBool);
    }
}
