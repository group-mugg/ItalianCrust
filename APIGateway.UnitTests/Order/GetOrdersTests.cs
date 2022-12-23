using Moq;
using System.Net;
using APIGateway.Clients;
using APIGateway.Services.Order;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIGateway.UnitTests.Order
{
    public class GetOrdersTests
    {

        [Fact]
        public async void GetAllOrders_WhenOrderExists_ReturnsOk()
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.GetAllOrders()).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new GetAllOrdersService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetAllOrders(), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void GetAllOrders_WhenOrderIsMissing_ReturnsNotFound()
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.GetAllOrders()).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new GetAllOrdersService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetAllOrders(), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }


        [Theory]
        [InlineData(0)]
        public async void GetOrderById_WhenOrderExists_ReturnsOk(int id)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.GetOrderById(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new GetOrderByIdService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetOrderById(id), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void GetOrderById_WhenOrderIsMissing_ReturnsNotFound(int id)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.GetOrderById(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new GetOrderByIdService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.GetOrderById(id), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }


    }
}
