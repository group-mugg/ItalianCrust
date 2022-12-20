using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Models;
using Order.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.UnitTests.MoqTests;

public class GetAllPizzasHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenThereArePizzasInTheDatabase_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.GetAllPizzas())
            .ReturnsAsync(new List<PizzaDTO>
            {
                new PizzaDTO { Id = 1 },
                new PizzaDTO { Id = 2 },
                new PizzaDTO { Id = 3 }
            });

        //Act
        var okResult = (Ok<IEnumerable<PizzaDTO>>)await GetAllPizzasHandler.HandleAsync(mock.Object);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundPizzas = Assert.IsAssignableFrom<IEnumerable<PizzaDTO>>(okResult.Value);

        Assert.NotEmpty(foundPizzas);
        Assert.Collection(foundPizzas, pizza1 =>
        {
            Assert.Equal(1, pizza1.Id);
        }, pizza2 =>
        {
            Assert.Equal(2, pizza2.Id);
        }, pizza3 =>
        {
            Assert.Equal(3, pizza3.Id);
        });
    }
}
