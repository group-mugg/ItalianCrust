using Order.Api.Extensions;
using Order.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add services below.
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

app.MapEndpoints();

app.Run();
