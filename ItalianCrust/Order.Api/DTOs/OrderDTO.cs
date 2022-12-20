namespace Order.Api.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalOrder { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<OrderRowDTO> OrderRowDTOs { get; set; } = new List<OrderRowDTO>();
}
