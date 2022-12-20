using Order.Api.Extensions;
using Order.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add services below.
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

app.MapEndpoints();

app.Run();
