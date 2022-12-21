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
using System.Xml.Linq;

namespace Pizza.UnitTests.MoqTests;

public class GetAllPizzasHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenReturningAllPizzas_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IPizzaRepository>();

        mock.Setup(m => m.GetAllPizzas())
            .ReturnsAsync(
                new List<PizzaDTO>
                {
                    new PizzaDTO { Id = 1, Name = "Mock", Description = "Mock", Price = 1.00m },
                    new PizzaDTO { Id = 2, Name = "Mock2", Description = "Mock2", Price = 1.00m },
                    new PizzaDTO { Id = 3, Name = "Mock3", Description = "Mock3", Price = 1.00m }
                }
            );

        //Act
        var okResult = (Ok<IEnumerable<PizzaDTO>>)await GetAllPizzasHandler.HandleAsync(mock.Object);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var returnedPizzas = Assert.IsAssignableFrom<IEnumerable<PizzaDTO>>(okResult.Value);
        Assert.NotEmpty(returnedPizzas);
        Assert.Collection(returnedPizzas, pizza1 =>
        {
            Assert.Equal(1, pizza1.Id);
        },
        pizza2 =>
        {
            Assert.Equal(2, pizza2.Id);
        },
        pizza3 =>
        {
            Assert.Equal(3, pizza3.Id);
        }
        );
    }
}
