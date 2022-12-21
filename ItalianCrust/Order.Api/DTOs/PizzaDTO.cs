using Order.Api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.Api.DTOs;

public class PizzaDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
