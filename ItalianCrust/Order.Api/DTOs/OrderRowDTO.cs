namespace Order.Api.DTOs;

public class OrderRowDTO
{
    public int OrderId { get; set; }
    public int PizzaId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PricePerPc { get; set; }
    public decimal TotalRow { get; set; }
}
