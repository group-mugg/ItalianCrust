using Order.Api.Extensions;
using Order.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ModelDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
    options.UseSqlServer(connectionString);
});

//Add services below.
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

app.MapEndpoints();

app.Run();
