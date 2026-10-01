using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ParcelDesk.Api.Data;
using ParcelDesk.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var databaseProvider = builder.Configuration["Database:Provider"] ?? "MySql";

var connectionString =
    builder.Configuration.GetConnectionString("ParcelDeskDb")
        ?? throw new InvalidOperationException("Connection string 'ParcelDeskDb' was not found.");

builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter());
                });

builder.Services.AddDbContext<ParcelDbContext>(
    options =>
    {
    switch (databaseProvider.ToLowerInvariant())
        {
            case "sqlite":
                options.UseSqlite(connectionString);
                break;
            case "mysql":
                options.UseMySQL(connectionString);
                break;
            default:
                throw new InvalidOperationException($"Unsupported database provider: {databaseProvider}");
        }
    });

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ShipmentService>();
builder.Services.AddScoped<DashboardService>();

var app = builder.Build();

if (databaseProvider.Equals("Sqlite", StringComparison.OrdinalIgnoreCase))
{
    using var scope = app.Services.CreateScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<ParcelDbContext>();

    await dbContext.Database.EnsureCreatedAsync();
}

app.MapControllers();

app.Run();
