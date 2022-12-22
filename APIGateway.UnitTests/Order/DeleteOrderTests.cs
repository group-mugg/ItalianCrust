using APIGateway.Clients;
using APIGateway.Services.Order;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System.Net;

namespace APIGateway.UnitTests.Order
{
    public class DeleteOrderTests
    {

        [Theory]
        [InlineData(0)]
        public async void DeleteOrder_WhenOrderExsists_ReturnsOk(int id)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.DeleteOrder(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new DeleteOrderService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.DeleteOrder(id), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void DeleteOrder_WhenOrderIsMissing_ReturnsNotFound(int id)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.DeleteOrder(id)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new DeleteOrderService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.DeleteOrder(id), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }

    }
}
