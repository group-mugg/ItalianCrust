using Microsoft.EntityFrameworkCore;
using Pizza.Api.DAL;
using Pizza.Api.Extensions;
using Pizza.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add services below.
builder.Services.AddDbContext<PizzaContext>(options =>
{
    var connextionString = "Server=localhost;Database=ItalianCrustPizzaDb;Trusted_Connection=True;TrustServerCertificate=True";
    options.UseSqlServer(connextionString);
});
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

app.MapEndpoints();

app.Run();


