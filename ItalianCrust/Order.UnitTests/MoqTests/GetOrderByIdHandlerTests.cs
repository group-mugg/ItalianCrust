using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Order.Api.DTOs;
using Order.Api.Handlers;
using Order.Api.Repositories;

namespace Order.UnitTests.MoqTests;

public class GetOrderByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenOrderDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.GetOrderById(It.Is<int>(id => id == 1)))
            .ReturnsAsync((OrderDTO?)null);

        //Act
        var notFoundResult = (NotFound)await GetOrderByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task HandleAsync_WhenOrderExists_ReturnsOk()
    {
        //Arrange
        var mock = new Mock<IOrderRepository>();

        mock.Setup(m => m.GetOrderById(It.Is<int>(id => id == 1)))
            .ReturnsAsync(new OrderDTO {
                Id = 1,
                CustomerName = "TestCustomer",
                TotalOrder = 5.00M,
                OrderDate = new DateTime(2022, 12, 1),
                OrderRowDTOs = new List<OrderRowDTO>
                {
                    new OrderRowDTO { OrderId = 1, PizzaId = 1, Name = "Pizza1", Quantity = 1, PricePerPc = 1.00M, TotalRow = 1.00M },
                    new OrderRowDTO { OrderId = 1, PizzaId = 2, Name = "Pizza2", Quantity = 2, PricePerPc = 2.00M, TotalRow = 4.00M }
                }
            });

        //Act
        var okResult = (Ok<OrderDTO>)await GetOrderByIdHandler.HandleAsync(mock.Object, 1);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundOrder = Assert.IsAssignableFrom<OrderDTO>(okResult.Value);
        Assert.Equal(1, foundOrder.Id);
        Assert.Equal("TestCustomer", foundOrder.CustomerName);
        Assert.Equal(5.00M, foundOrder.TotalOrder);
        Assert.Equal(new DateTime(2022, 12, 1), foundOrder.OrderDate);
        Assert.Equal(2, foundOrder.OrderRowDTOs.Count);
        Assert.Equal(1, foundOrder.OrderRowDTOs.First().OrderId);
        Assert.Equal(1, foundOrder.OrderRowDTOs.First().PizzaId);
        Assert.Equal(1, foundOrder.OrderRowDTOs.Last().OrderId);
        Assert.Equal(2, foundOrder.OrderRowDTOs.Last().PizzaId);
        Assert.Equal(3, foundOrder.OrderRowDTOs.Select(or => or.Quantity).Sum());
        Assert.Equal(5.00M, foundOrder.OrderRowDTOs.Select(or => or.TotalRow).Sum());
    }
}
