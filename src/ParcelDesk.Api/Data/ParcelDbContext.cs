using Microsoft.EntityFrameworkCore;
using ParcelDesk.Api.Models;

namespace ParcelDesk.Api.Data;

public class ParcelDbContext : DbContext
{
    public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers => Set<Customer>();
}