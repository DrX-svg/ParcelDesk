using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParcelDesk.Api.Data;
using ParcelDesk.Api.Models;

namespace ParcelDesk.Api.Services;

public class ShipmentService
{
    private readonly ParcelDbContext _dbContext;

    public ShipmentService(ParcelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Shipment>> GetAllAsync()
    {
        return await _dbContext.Shipments
                                        .AsNoTracking()
                                        .Include(shipment => shipment.Customer)
                                        .OrderByDescending(shipment => shipment.CreatedAtUtc)
                                        .ToListAsync();
    }

    public async Task<Shipment?> GetByIdAsync(int id)
    {
        return await _dbContext.Shipments
                                        .AsNoTracking()
                                        .Include(shipment => shipment.Customer)
                                        .FirstOrDefaultAsync(shipment => shipment.Id == id);
    }

    public async Task<Shipment?> GetByAwbAsync(string awb)
    {
        var normalizedAwb = awb
                                .Trim()
                                .ToUpperInvariant();

        return await _dbContext.Shipments
                                        .AsNoTracking()
                                        .Include(shipment => shipment.Customer)
                                        .FirstOrDefaultAsync(shipment => shipment.Awb == normalizedAwb);
    }

    public async Task<Shipment?> CreateAsync(
        int customerId,
        string senderAddress,
        string destinationAddress,
        string city,
        decimal weight,
        string? notes)
    {
        var customer = await _dbContext.Customers
                                                .FirstOrDefaultAsync(customer => customer.Id == customerId);

        if (customer is null)
        {
            return null;
        }

        var now = DateTime.UtcNow;

        var shipment = new Shipment
        {
            Awb = GenerateAwb(),
            CustomerId = customer.Id,
            SenderAddress = senderAddress.Trim(),
            DestinationAddress = destinationAddress.Trim(),
            City = city.Trim(),
            Weight = weight,
            Status = ShipmentStatus.Created,
            CreatedAtUtc = now,
            UpdatedAtUtc = now,
            Notes = string.IsNullOrWhiteSpace(notes) ? null : notes.Trim(),
            Customer = customer
        };

        _dbContext.Shipments.Add(shipment);

        await _dbContext.SaveChangesAsync();

        return shipment;

    }
        private static string GenerateAwb()
    {
        var randomPart = Guid.NewGuid()
                                        .ToString("N")[..20]
                                        .ToUpperInvariant();
        return $"PD-{randomPart}";
    }
}