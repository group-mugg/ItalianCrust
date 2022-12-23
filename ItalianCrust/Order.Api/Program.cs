using Order.Api.Extensions;
using Order.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID=sa;Password={password};Trusted_connection=False;TrustServerCertificate=True;";

builder.Services.AddSqlServer<ModelDbContext>(connectionString);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

app.MapEndpoints();

app.Run();
