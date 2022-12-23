using Microsoft.EntityFrameworkCore;
using Order.Api.Models;

namespace Order.Api.Repositories
{
    public class ModelDbContext : DbContext
    {

        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderRow> OrderRows { get; set; }
        public DbSet<Models.Pizza> Pizzas { get; set; }

        public ModelDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderRow>()
            .HasKey(or => new { or.OrderId, or.PizzaId });

            modelBuilder.Entity<OrderRow>()
                .HasOne(or => or.Order)
                .WithMany(o => o.OrderRows)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<OrderRow>()
                .HasOne(or => or.Pizza)
                .WithMany(p => p.OrderRows)
                .HasForeignKey(or => or.PizzaId);

            modelBuilder.Entity<Models.Pizza>()
                .HasData(
                new Models.Pizza { Id = 1, Name = "Pizza1", Price = 109.99M },
                new Models.Pizza { Id = 2, Name = "Pizza2", Price = 119.99M },
                new Models.Pizza { Id = 3, Name = "Pizza3", Price = 129.99M }
                );
        }
    }
}
