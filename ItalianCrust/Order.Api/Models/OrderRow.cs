using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Order.Api.Models;

public class OrderRow
{
    public int OrderId { get; set; }
    public int PizzaId { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerPc { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }
    [JsonIgnore]
    public virtual Order Order { get; set; }
    [JsonIgnore]
    public virtual Pizza Pizza { get; set; }
}
