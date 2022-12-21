using Microsoft.EntityFrameworkCore;

namespace Order.Api.Repositories
{
    public class ModelDbContext : DbContext
    {
        public DbSet<OrderRepository> Orders { get; set; }

        public ModelDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
