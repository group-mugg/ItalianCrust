using Microsoft.EntityFrameworkCore;
using Pizza.Api.DAL;
using Pizza.Api.Extensions;
using Pizza.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add services below.
builder.Services.AddDbContext<PizzaContext>(o => o.UseInMemoryDatabase("PizzaDB"));
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

app.MapEndpoints();

app.Run();
