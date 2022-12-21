using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

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
                new PizzaDTO { Id = 1, Name = "Pizza1", Price = 1.00M },
                new PizzaDTO { Id = 2, Name = "Pizza2", Price = 2.00M },
                new PizzaDTO { Id = 3, Name = "Pizza3", Price = 3.00M }
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
            Assert.Equal("Pizza1", pizza1.Name);
            Assert.Equal(1.00M, pizza1.Price);
        }, pizza2 =>
        {
            Assert.Equal(2, pizza2.Id);
            Assert.Equal("Pizza2", pizza2.Name);
            Assert.Equal(2.00M, pizza2.Price);
        }, pizza3 =>
        {
            Assert.Equal(3, pizza3.Id);
            Assert.Equal("Pizza3", pizza3.Name);
            Assert.Equal(3.00M, pizza3.Price);
        });
    }
}
