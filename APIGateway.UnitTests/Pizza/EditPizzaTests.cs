using APIGateway.Clients;
using APIGateway.Services.Pizza;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIGateway.UnitTests.Pizza
{
    public class EditPizzaTests
    {

        [Theory]
        [InlineData(0, "Test", 12.3)]
        public async void EditPizza_WhenPizzaExists_ReturnsOk(int id, string name, decimal price)
            //Här vill vi nog ta emot ett JSON-objekt istället
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.EditPizza(id, name, price)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new EditPizzaService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.EditPizza(id, name, price), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [InlineData(0, "Test", 12.3)]
        public async void EditPizza_WhenPizzaIsMissing_ReturnsNotFound(int id, string name, decimal price)
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.EditPizza(id, name, price)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new EditPizzaService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.EditPizza(id, name, price), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }


    }
}
