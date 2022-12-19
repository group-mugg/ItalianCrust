using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Pizza.Api.DTOs;
using Pizza.Api.Handlers;
using Pizza.Api.Repositories;

namespace Pizza.UnitTests.MoqTests;

public class GetPizzaByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenPizzaDoesNotExist_ReturnsNotFound()
    {
        //Arrange

        //Act

        //Assert

    }

    [Fact]
    public async Task HandleAsync_WhenPizzaExists_ReturnsOk()
    {
        //Arrange

        //Act

        //Assert
        
    }
}
