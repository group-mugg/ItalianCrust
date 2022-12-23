using Moq;
using Order.Api.Repositories;
using Order.Api.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Order.Api.Handlers;

namespace Order.UnitTests.MoqTests;

public class GetPizzaByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenPizzaDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.GetPizzaById(It.Is<int>(id => id == 1)))
            .ReturnsAsync((PizzaDTO?)null);

        //Act
        var notFoundResult = (NotFound)await GetPizzaByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task HandleAsync_WhenPizzaExists_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.GetPizzaById(It.Is<int>(id => id == 1)))
            .ReturnsAsync(new PizzaDTO { Id = 1, Name = "TestPizza", Price = 1.00M });

        //Act
        var okResult = (Ok<PizzaDTO>)await GetPizzaByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundPizza = Assert.IsAssignableFrom<PizzaDTO>(okResult.Value);
        Assert.Equal(1, foundPizza.Id);
        Assert.Equal("TestPizza", foundPizza.Name);
        Assert.Equal(1.00M, foundPizza.Price);
    }
}
