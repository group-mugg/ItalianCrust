using System.Net;
using APIGateway.Clients;
using APIGateway.Services.Pizza;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace APIGateway.UnitTests.Pizza
{
    public class DeletePizzaTests
    {

        [Theory]
        [InlineData(0)]
        public async void DeletePizza_WhenPizzaExsists_ReturnsOk(int id)
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.DeletePizza(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new DeletePizzaService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.DeletePizza(id), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void DeletePizza_WhenPizzaIsMissing_ReturnsNotFound(int id)
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.DeletePizza(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new DeletePizzaService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.DeletePizza(id), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }

    }
}
