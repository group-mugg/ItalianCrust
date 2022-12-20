namespace Order.Api.Requests;

public class CreateOrderRequest
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<int, int> ProductIdQuantity { get; set; } = new Dictionary<int, int>();
}
