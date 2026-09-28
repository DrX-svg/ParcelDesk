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

    public async Task<List<Shipment>> GetAllAsync(
        ShipmentStatus? status,
        int? customerId,
        string? city,
        string? search)
    {
        IQueryable<Shipment> query = _dbContext.Shipments
                                                        .AsNoTracking()
                                                        .Include(shipment => shipment.Customer);

        if (status.HasValue)
        {
            query = query.Where(shipment => shipment.Status == status.Value);
        }

        if (customerId.HasValue)
        {
            query = query.Where(shipment => shipment.CustomerId == customerId.Value);
        }

        if (!string.IsNullOrWhiteSpace(city))
        {
            var cityTerm = city.Trim();

            query = query.Where(shipment => shipment.City.Contains(cityTerm));
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchTerm = search.Trim();

            query = query.Where(shipment =>
                                    shipment.Awb.Contains(searchTerm)
                                    || shipment.City.Contains(searchTerm)
                                    || shipment.Customer.Name.Contains(searchTerm)
                                    || shipment.SenderAddress.Contains(searchTerm)
                                    || shipment.DestinationAddress.Contains(searchTerm)
                                    || (shipment.Notes != null && shipment.Notes.Contains(searchTerm)));
        }

        return await query.OrderByDescending(shipment => shipment.CreatedAtUtc).ToListAsync();
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

        var initialHistory = new ShipmentStatusHistory
        {
            Shipment = shipment,
            Status = ShipmentStatus.Created,
            ChangedAtUtc = now
        };

        _dbContext.ShipmentStatusHistories.Add(initialHistory);

        await _dbContext.SaveChangesAsync();

        return shipment;
    }

    public async Task<Shipment?> UpdateAsync(
        int id,
        string senderAddress,
        string destinationAddress,
        string city,
        decimal weight,
        string? notes
    )
    {
        var shipment = await _dbContext.Shipments
                                                .Include(shipment => shipment.Customer)
                                                .FirstOrDefaultAsync(shipment => shipment.Id == id);

        if (shipment is null)
        {
            return null;
        }

        shipment.SenderAddress = senderAddress.Trim();
        shipment.DestinationAddress = destinationAddress.Trim();
        shipment.City = city.Trim();
        shipment.Weight = weight;
        shipment.Notes = string.IsNullOrWhiteSpace(notes) 
                                                    ? null 
                                                    : notes.Trim();

        shipment.UpdatedAtUtc = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return shipment;
    }

    public async Task<ShipmentStatusChangeResult> ChangeStatusAsync(
        int id,
        ShipmentStatus newStatus)
    {
        var shipment = await _dbContext.Shipments
                                                .FirstOrDefaultAsync(shipment => shipment.Id == id);
        if (shipment is null)
        {
            return ShipmentStatusChangeResult.NotFound;
        }

        if (!IsTransitionAllowed(shipment.Status, newStatus))
        {
            return ShipmentStatusChangeResult.InvalidTransition;
        }

        var now = DateTime.UtcNow;

        shipment.Status = newStatus;
        shipment.UpdatedAtUtc = now;

        var historyEntry = new ShipmentStatusHistory
        {
            ShipmentId = shipment.Id,
            Status = newStatus,
            ChangedAtUtc = now
        };

        _dbContext.ShipmentStatusHistories.Add(historyEntry);

        await _dbContext.SaveChangesAsync();

        return ShipmentStatusChangeResult.Updated;
    }

    public async Task<List<ShipmentStatusHistory>?> GetHistoryAsync(
        int shipmentId)
    {
        var shipmentExists = await _dbContext.Shipments
                                                    .AnyAsync(shipment => shipment.Id == shipmentId);

        if (!shipmentExists)
        {
            return null;
        }

        return await _dbContext.ShipmentStatusHistories
                                                    .AsNoTracking()
                                                    .Where(history => history.ShipmentId == shipmentId)
                                                    .OrderBy(history => history.ChangedAtUtc)
                                                    .ToListAsync();
    }

    private static string GenerateAwb()
    {
        var randomPart = Guid.NewGuid()
                                        .ToString("N")[..20]
                                        .ToUpperInvariant();
        return $"PD-{randomPart}";
    }

    private static bool IsTransitionAllowed(
        ShipmentStatus currentStatus,
        ShipmentStatus newStatus)
    {
        return currentStatus switch
        {
            ShipmentStatus.Created =>
                newStatus is ShipmentStatus.PickedUp
                            or ShipmentStatus.Cancelled,

            ShipmentStatus.PickedUp =>
                newStatus is ShipmentStatus.InTransit
                            or ShipmentStatus.Cancelled,

            ShipmentStatus.InTransit =>
                newStatus is ShipmentStatus.Delivered
                            or ShipmentStatus.Cancelled,

            ShipmentStatus.Delivered => false,

            ShipmentStatus.Cancelled => false,

            _ => false
        };
    }

}