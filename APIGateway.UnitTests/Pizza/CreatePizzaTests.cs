using APIGateway.Clients;
using APIGateway.Services.Pizza;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIGateway.UnitTests.Pizza
{
    public class CreatePizzaTests
    {
        [Theory]
        [InlineData("Test", 12.3)]
        public async void CreatePizza_WhenPizzaExists_ReturnsOk(string name, decimal price)
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.CreatePizza(name, price)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new CreatePizzaService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.CreatePizza(name, price), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [InlineData("Test", 12.3)]
        public async void CreatePizza_WhenPizzaIsMissing_ReturnsNotFound(string name, decimal price)
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.CreatePizza(name, price)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new CreatePizzaService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.CreatePizza(name, price), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }

    }
}
