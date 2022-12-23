using System.ComponentModel.DataAnnotations.Schema;

namespace Order.Api.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public virtual ICollection<OrderRow> OrderRows { get; set; }
}
