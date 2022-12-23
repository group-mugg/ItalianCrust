using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Pizza.Api.DTOs;
using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.UnitTests.MoqTests;

public class CreatePizzaHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenPostingValidRequest_CreatePizza()
    {
        //Arrange
        PizzaDTO pizza = new() { Id = 1, Name = "Mock", Description = "Mock", Price = 1.00m };
        var mock = new Mock<IPizzaRepository>();
        mock.Setup(m => m.CreatePizza(It.Is<PizzaDTO>(req => req.Id == pizza.Id && req.Name == pizza.Name && req.Description == pizza.Description && req.Price == pizza.Price)))
            .ReturnsAsync(true);

        //Act
        var okResult = (Ok<bool>)await CreatePizzaHandler.HandleAsync(mock.Object, pizza);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var isOk = Assert.IsAssignableFrom<bool>(okResult.Value);
        Assert.True(isOk);
    }

    [Fact]
    public async Task HandleAsync_WhenPostingWithNegativePrice_DoNotCreatePizza()
    {
        //Arrange
        PizzaDTO pizza = new() { Id = 1, Name = "Mock", Description = "Mock", Price = -1.00m };
        var mock = new Mock<IPizzaRepository>();
        mock.Setup(m => m.CreatePizza(It.Is<PizzaDTO>(req => req.Id == pizza.Id && req.Name == pizza.Name && req.Description == pizza.Description && req.Price == pizza.Price)))
            .ReturnsAsync(false);

        //Act
        var badRequestResult = (BadRequest<bool>)await CreatePizzaHandler.HandleAsync(mock.Object, pizza);

        //Assert
        Assert.Equal(400, badRequestResult.StatusCode);
        var isNotOk = Assert.IsAssignableFrom<bool>(badRequestResult.Value);
        Assert.False(isNotOk);
    }
}