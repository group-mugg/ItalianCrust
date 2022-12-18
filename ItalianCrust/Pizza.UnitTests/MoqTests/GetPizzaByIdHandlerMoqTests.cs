using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.UnitTests.MoqTests;

public class GetPizzaByIdHandlerMoqTests
{
    [Fact]
    public async Task HandleAsync_WhenPizzaDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.GetPizzaById(It.Is<int>(id => id == 1)))
            .ReturnsAsync((Api.Models.Pizza?)null);

        //Act
        var notFoundResult = (NotFound)await GetPizzaByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task HandleAsync_WhenPizzExists_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.GetPizzaById(It.Is<int>(id => id == 1)))
            .ReturnsAsync(
                new Api.Models.Pizza { Id = 1, Name = "P1", Description = "D1", Price = 1.11M }
            );

        //Act
        var okResult = (Ok<Api.Models.Pizza>)await GetPizzaByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundPizza = Assert.IsAssignableFrom<Api.Models.Pizza>(okResult.Value);
        Assert.Equal(1, foundPizza.Id);
    }
}
