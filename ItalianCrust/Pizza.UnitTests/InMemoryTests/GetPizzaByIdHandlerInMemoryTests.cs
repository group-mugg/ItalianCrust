using Pizza.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Pizza.Api.Handlers;
using Pizza.UnitTests.Helpers;

namespace Pizza.UnitTests.InMemoryTests;

public class GetPizzaByIdHandlerInMemoryTests
{
    [Fact]
    public async Task HandleAsync_WhenPizzaDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        await using var context = new MockDb().CreateDbContext();
        var pizzaRepository = new PizzaRepository(context);

        //Act
        var notFoundResult = (NotFound)await GetPizzaByIdHandler.HandleAsync(pizzaRepository, 1);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task HandleAsync_WhenPizzaExists_ReturnsOk()
    {
        //Arrange
        await using var context = new MockDb().CreateDbContext();
        var pizzaRepository = new PizzaRepository(context);

        await pizzaRepository.CreatePizza(new Api.Models.Pizza { Id = 1, Name = "P1", Description = "D1", Price = 1.11M });

        //Act
        var okResult = (Ok<Api.Models.Pizza>)await GetPizzaByIdHandler.HandleAsync(pizzaRepository, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundPizza = Assert.IsAssignableFrom<Api.Models.Pizza>(okResult.Value);
        Assert.Equal(1, foundPizza.Id);
    }
}
