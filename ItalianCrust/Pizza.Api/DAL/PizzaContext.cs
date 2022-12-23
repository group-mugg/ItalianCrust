using Microsoft.EntityFrameworkCore;

namespace Pizza.Api.DAL;

public class PizzaContext : DbContext
{
    public DbSet<Models.Pizza> Pizzas { get; set; }
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Pizza>()
            .HasData(
                new Models.Pizza { Id = 1, Name = "Pizza1", Description = "Description1", Price = 109.99M },
                new Models.Pizza { Id = 2, Name = "Pizza2", Description = "Description2", Price = 119.99M },
                new Models.Pizza { Id = 3, Name = "Pizza3", Description = "Description3", Price = 129.99M }
            );
    }
}
