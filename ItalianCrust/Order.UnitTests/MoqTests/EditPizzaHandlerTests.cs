using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.UnitTests.MoqTests;

public class EditPizzaHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenValidRequest_ReturnsOk()
    {
        //Arrange
        var request = new PizzaDTO { Id = 1, Name = "EditedPizza", Price = 1.00M };

        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.EditPizza(It.Is<PizzaDTO>(req => req.Id == request.Id && req.Name == request.Name && req.Price == request.Price)))
            .ReturnsAsync(true);

        //Act
        var okResult = (Ok<bool>)await EditPizzaHandler.HandleAsync(mock.Object, request);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(okResult.Value);
        Assert.True(response);
    }

    [Theory]
    [InlineData("", 1)]//When name is empty
    [InlineData(null, 1)]//When name is null
    [InlineData("EditedPizza", -1)]//When price is negative
    public async Task HandleAsync_WhenInvalidRequest_ReturnsBadRequest(string name, decimal price)
    {
        //Arrange
        var request = new PizzaDTO { Id = 1, Name = name, Price = price };

        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.EditPizza(It.Is<PizzaDTO>(req => req.Id == request.Id && req.Name == request.Name && req.Price == request.Price)))
            .ReturnsAsync(false);

        //Act
        var badRequestResult = (BadRequest<bool>)await EditPizzaHandler.HandleAsync(mock.Object, request);

        //Assert
        Assert.Equal(400, badRequestResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(badRequestResult.Value);
        Assert.False(response);
    }
}
