using APIGateway.Clients;
using APIGateway.Services.Order;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System.Net;

namespace APIGateway.UnitTests.Order
{
    public class CreateOrderTests
    {

        [Theory]
        [MemberData(nameof(Data))]
        public void CreateOrder_MakesUpdateRequest(string? name, Dictionary<int, int> pizzasIdQuantity)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.CreateOrder(name, pizzasIdQuantity)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new EditOrderService(mock.Object);

            //Act
            var result = service.HandleAsync();

            //Assert
            mock.Verify(x => x.EditOrder(name, pizzasIdQuantity), Times.Once());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void CreateOrder_WhenOrderExits_ReturnsOk(string name, Dictionary<int, int> pizzasIdQuantity)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.CreateOrder(name, pizzasIdQuantity)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var service = new CreateOrderService(mock.Object);

            //Act
            var result = (Ok)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.CreateOrder(name, pizzasIdQuantity), Times.Once());
            Assert.Equal(200, result.StatusCode);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public async void CreateOrder_WhenOrderIsMissing_ReturnsNotFound(string name, Dictionary<int, int> pizzasIdQuantity)
        {
            //Arrange
            var mock = new Mock<IOrderClient>();
            mock.Setup(x => x.CreateOrder(name, pizzasIdQuantity)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var service = new CreateOrderService(mock.Object);

            //Act
            var result = (NotFound)await service.HandleAsync();

            //Assert
            mock.Verify(x => x.CreateOrder(name, pizzasIdQuantity), Times.Once());
            Assert.Equal(404, result.StatusCode);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { "Test", null };
            yield return new object[] { null, new Dictionary<int, int> { { 0, 1 } } };
        }

    }
}
