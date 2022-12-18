using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Pizza.Api.DAL;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Models.Pizza>()
    //        .HasData(
    //            new Models.Pizza { Id = 1, Name = "P1", Description = "D1", Price = 1.11M }
    //        );
    //}

    public DbSet<Models.Pizza> Pizzas { get; set; }
}
