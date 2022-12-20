using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Pizza.Api.DTOs;
using Pizza.Api.Handlers;
using Pizza.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.UnitTests.MoqTests;

public class EditPizzaHandlerTests
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
    public async Task HandleAsync_WhenPizzaExists_EditsPizza()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.GetPizzaById(It.Is<int>(id => id == 1)))
            .ReturnsAsync(
                new PizzaDTO { Id = 1, Name = "Mock", Description = "Mock", Price = 1.00m }
            );

        //Act
        var okResult = (Ok<PizzaDTO>)await GetPizzaByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var returnedPizza = Assert.IsAssignableFrom<PizzaDTO>(okResult.Value);
        returnedPizza.Name = "Edited mock";
        Assert.Equal("Edited mock", returnedPizza.Name);
    }
}
