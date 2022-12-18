using Microsoft.EntityFrameworkCore;
using Pizza.Api.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.UnitTests.Helpers;

public class MockDb : IDbContextFactory<PizzaContext>
{
    public PizzaContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<PizzaContext>()
            .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
            .Options;

        return new PizzaContext(options);
    }
}
