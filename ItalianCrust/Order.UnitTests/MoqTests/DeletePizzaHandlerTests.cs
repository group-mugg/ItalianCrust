﻿using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.UnitTests.MoqTests;

public class DeletePizzaHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenDeletingExistingPizza_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.DeletePizza(It.Is<int>(id => id == 1)))
            .ReturnsAsync(true);

        //Act
        var okResult = (Ok<bool>)await DeletePizzaHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(okResult.Value);
        Assert.True(response);
    }

    [Fact]
    public async Task HandleAsync_WhenTryingToDeleteUnexistingPizza_ReturnsNotFound()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.DeletePizza(It.Is<int>(id => id == 1)))
            .ReturnsAsync(false);

        //Act
        var notFoundResult = (BadRequest<bool>)await DeletePizzaHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
        var response = Assert.IsAssignableFrom<bool>(notFoundResult.Value);
        Assert.False(response);
    }
}