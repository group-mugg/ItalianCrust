using Microsoft.EntityFrameworkCore;
using Order.Api.DTOs;
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
        }
    }
}
