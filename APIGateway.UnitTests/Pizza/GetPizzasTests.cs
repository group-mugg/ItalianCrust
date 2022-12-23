using Moq;
using System.Net;
using APIGateway.Clients;
using APIGateway.Services.Pizza;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIGateway.UnitTests.Pizza
{
    public class GetPizzasTests
    {

        [Fact]
        public async void GetAllPizzas_WhenPizzasExists_ReturnsOk()
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.GetAllPizzas()).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new GetAllPizzasService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetAllPizzas(), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void GetAllPizzas_WhenPizzasIsMissing_ReturnsNotFound()
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.GetAllPizzas()).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new GetAllPizzasService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetAllPizzas(), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }


        [Theory]
        [InlineData(0)]
        public async void GetPizzaById_WhenPizzaExists_ReturnsOk(int id)
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.GetPizzaById(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new GetPizzaByIdService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetPizzaById(id), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void GetPizzaById_WhenPizzaIsMissing_ReturnsNotFound(int id)
        {
            //Arrange
            var mock = new Mock<IPizzaClient>();
            mock.Setup(x => x.GetPizzaById(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new GetPizzaByIdService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetPizzaById(id), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }

    }
}
