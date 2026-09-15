using Microsoft.EntityFrameworkCore;
using ParcelDesk.Api.Data;
using ParcelDesk.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ParcelDeskDb") 
    ?? throw new InvalidOperationException("Connection string 'ParcelDeskDb' was not found.");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ParcelDbContext>(options => options.UseMySQL(connectionString));

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ShipmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
