using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Pizza.Api.DAL;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
    {
    }

    public DbSet<Models.Pizza> Pizzas { get; set; }
}
