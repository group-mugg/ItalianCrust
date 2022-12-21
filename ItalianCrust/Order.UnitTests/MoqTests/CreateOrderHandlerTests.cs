using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.Handlers;
using Order.Api.Repositories;
using Order.Api.Requests;

namespace Order.UnitTests.MoqTests;

public class CreateOrderHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenValidRequest_ReturnsOk()
    {
        //Arrange
        var request = new CreateOrderRequest { Name = "TestCustomer", PizzaIdQuantity = new Dictionary<int, int> { { 1, 1 } } };

        var orderMock = new Mock<IOrderRepository>();

        orderMock.Setup(m => m.CreateOrder(It.Is<CreateOrderRequest>(req => req.Name == request.Name && req.PizzaIdQuantity == request.PizzaIdQuantity)))
            .ReturnsAsync(true);

        //Act
        var okResult = (Ok<bool>)await CreateOrderHandler.HandleAsync(orderMock.Object, request);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(okResult.Value);
        Assert.True(response);
    }

    [Fact]
    public async Task HandleAsync_WhenRequestNameIsNullOrEmpty_ReturnsBadRequest()
    {
        //Arrange
        var request = new CreateOrderRequest { Name = "", PizzaIdQuantity = new Dictionary<int, int> { { 1, 1 } } };

        var orderMock = new Mock<IOrderRepository>();

        orderMock.Setup(m => m.CreateOrder(It.Is<CreateOrderRequest>(req => req.Name == request.Name && req.PizzaIdQuantity == request.PizzaIdQuantity)))
            .ReturnsAsync(false);

        //Act
        var badRequestResult = (BadRequest<bool>)await CreateOrderHandler.HandleAsync(orderMock.Object, request);

        //Assert
        Assert.Equal(400, badRequestResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(badRequestResult.Value);
        Assert.False(response);
    }

    [Fact]
    public async Task HandleAsync_WhenRequestPizzaIdQuantityCountIsZero_ReturnsBadRequest()
    {
        //Arrange
        var request = new CreateOrderRequest { Name = "TestCustomer", PizzaIdQuantity = new Dictionary<int, int>() };

        var orderMock = new Mock<IOrderRepository>();

        orderMock.Setup(m => m.CreateOrder(It.Is<CreateOrderRequest>(req => req.Name == request.Name && req.PizzaIdQuantity == request.PizzaIdQuantity)))
            .ReturnsAsync(false);

        //Act
        var badRequestResult = (BadRequest<bool>)await CreateOrderHandler.HandleAsync(orderMock.Object, request);

        //Assert
        Assert.Equal(400, badRequestResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(badRequestResult.Value);
        Assert.False(response);
    }

    //Warning! This tests assumes that there are less than 1000 pizzas in the database.
    [Fact]
    public async Task HandleAsync_WhenUnexistingPizzaIdIsUsedInTheRequest_ReturnsBadRequest()
    {
        //Arrange
        var request = new CreateOrderRequest { Name = "TestCustomer", PizzaIdQuantity = new Dictionary<int, int> { { 1000, 1 } } };

        var orderMock = new Mock<IOrderRepository>();

        orderMock.Setup(m => m.CreateOrder(It.Is<CreateOrderRequest>(req => req.Name == request.Name && req.PizzaIdQuantity == request.PizzaIdQuantity)))
            .ReturnsAsync(false);

        //Act
        var badRequestResult = (BadRequest<bool>)await CreateOrderHandler.HandleAsync(orderMock.Object, request);

        //Assert
        Assert.Equal(400, badRequestResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(badRequestResult.Value);
        Assert.False(response);
    }
}
