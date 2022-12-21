using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.UnitTests.MoqTests;

public class GetAllOrdersHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenThereAreOrdersInDatabase_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.GetAllOrders())
            .ReturnsAsync(new List<OrderDTO>
            {
                new OrderDTO
                {
                    Id = 1,
                    CustomerName = "Customer1",
                    TotalOrder = 1.00M,
                    OrderDate = new DateTime(2022, 12, 1),
                    OrderRowDTOs = new List<OrderRowDTO>
                    {
                        new OrderRowDTO { OrderId = 1, PizzaId = 1, Name = "Pizza1", Quantity = 1, PricePerPc = 1.00M, TotalRow = 1.00M }
                    }
                },
                new OrderDTO
                {
                    Id = 2,
                    CustomerName = "Customer2",
                    TotalOrder = 4.00M,
                    OrderDate = new DateTime(2022, 12, 2),
                    OrderRowDTOs = new List<OrderRowDTO>
                    {
                        new OrderRowDTO { OrderId = 2, PizzaId = 2, Name = "Pizza2", Quantity = 2, PricePerPc = 2.00M, TotalRow = 4.00M }
                    }
                }
            });

        //Act
        var okResult = (Ok<IEnumerable<OrderDTO>>)await GetAllOrdersHandler.HandleAsync(mock.Object);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundOrders = Assert.IsAssignableFrom<IEnumerable<OrderDTO>>(okResult.Value);

        Assert.NotEmpty(foundOrders);
        Assert.Collection(foundOrders, order1 =>
        {
            Assert.Equal(1, order1.Id);
            Assert.Equal("Customer1", order1.CustomerName);
            Assert.Equal(1.00M, order1.TotalOrder);
            Assert.Equal(new DateTime(2022, 12, 1), order1.OrderDate);
            Assert.Equal(2, order1.OrderRowDTOs.Count);
            Assert.Equal(1, order1.OrderRowDTOs.First().OrderId);
            Assert.Equal(1, order1.OrderRowDTOs.First().PizzaId);
            Assert.Equal(1, order1.OrderRowDTOs.Select(or => or.Quantity).Sum());
            Assert.Equal(1.00M, order1.OrderRowDTOs.Select(or => or.TotalRow).Sum());
        }, order2 =>
        {
            Assert.Equal(2, order2.Id);
            Assert.Equal("Customer2", order2.CustomerName);
            Assert.Equal(4.00M, order2.TotalOrder);
            Assert.Equal(new DateTime(2022, 12, 2), order2.OrderDate);
            Assert.Equal(2, order2.OrderRowDTOs.Count);
            Assert.Equal(2, order2.OrderRowDTOs.First().OrderId);
            Assert.Equal(2, order2.OrderRowDTOs.First().PizzaId);
            Assert.Equal(2, order2.OrderRowDTOs.Select(or => or.Quantity).Sum());
            Assert.Equal(4.00M, order2.OrderRowDTOs.Select(or => or.TotalRow).Sum());
        });
    }
}
