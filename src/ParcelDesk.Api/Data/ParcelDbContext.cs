using Microsoft.EntityFrameworkCore;
using ParcelDesk.Api.Models;

namespace ParcelDesk.Api.Data;

public class ParcelDbContext : DbContext
{
    public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Shipment> Shipments => Set<Shipment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Shipment>()
                                       .HasIndex(shipment => shipment.Awb)
                                       .IsUnique();

        modelBuilder.Entity<Shipment>()
                                       .Property(shipment => shipment.Weight)
                                       .HasPrecision(10, 2);
    
        modelBuilder.Entity<Shipment>()
                                       .Property(shipment => shipment.Status)
                                       .HasConversion<string>()
                                       .HasMaxLength(30);

        modelBuilder.Entity<Shipment>()
                                       .HasOne(shipment => shipment.Customer)
                                       .WithMany(customer => customer.Shipments)
                                       .HasForeignKey(shipment => shipment.CustomerId)
                                       .OnDelete(DeleteBehavior.Restrict);
    }
}