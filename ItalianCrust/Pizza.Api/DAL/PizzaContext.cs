using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Pizza.Api.DAL;

public class PizzaContext : DbContext
{
    public DbSet<Models.Pizza> Pizzas { get; set; }
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
    {

    }

}
