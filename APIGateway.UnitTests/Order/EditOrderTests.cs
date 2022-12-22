using APIGateway.Clients;
using APIGateway.Services.Order;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIGateway.UnitTests.Order
{

    public class EditOrderTests
    {

        [Theory]
        [MemberData(nameof(Data))]
        public async void EditOrder_WhenOrderExists_ReturnsOk(string name, Dictionary<int, int> pizzasIdQuantity)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.EditOrder(name, pizzasIdQuantity)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new EditOrderService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.EditOrder(name, pizzasIdQuantity), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void EditOrder_WhenOrderIsMissing_ReturnsNotFound(string name, Dictionary<int, int> pizzasIdQuantity)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.EditOrder(name, pizzasIdQuantity)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new EditOrderService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.EditOrder(name, pizzasIdQuantity), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { "Test", null };
            yield return new object[] { null, new Dictionary<int, int> { { 0, 1 } } };
        }

    }
}
