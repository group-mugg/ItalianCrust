using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.UnitTests.MoqTests;

public class CreatePizzaHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenValidRequest_ReturnsOk()
    {
        //Arrange
        var request = new PizzaDTO { Id = 1, Name = "test", Price = 1.00M };

        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.CreatePizza(It.Is<PizzaDTO>(req => req.Id == request.Id && req.Name == request.Name && req.Price == request.Price)))
            .ReturnsAsync(true);

        //Act
        var okResult = (Ok<bool>)await CreatePizzaHandler.HandleAsync(mock.Object, request);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        Assert.IsAssignableFrom<bool>(okResult.Value);
        Assert.True(okResult.Value);
    }

    [Theory]
    [InlineData(0, "TestPizza", "-1.00")]//When price is negative
    [InlineData(1, "", "1.00")]//When name is empty
    [InlineData(1, null, "1.00")]//When name is null
    public async Task HandleAsync_WhenInvalidRequest_ReturnsBadRequest(int id, string name, string price)
    {
        //Arrange
        decimal decimalPrice = decimal.Parse(price);
        var request = new PizzaDTO { Id = id, Name = name, Price = decimalPrice };

        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.CreatePizza(It.Is<PizzaDTO>(req => req.Id == request.Id && req.Name == request.Name && req.Price == request.Price)))
            .ReturnsAsync(false);

        //Act
        var badRequestResult = (BadRequest<bool>)await CreatePizzaHandler.HandleAsync(mock.Object, request);

        //Assert
        Assert.Equal(200, badRequestResult.StatusCode);
        Assert.IsAssignableFrom<bool>(badRequestResult.Value);
        Assert.True(badRequestResult.Value);
    }
}
