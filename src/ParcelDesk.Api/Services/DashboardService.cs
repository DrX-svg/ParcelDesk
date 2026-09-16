using Microsoft.EntityFrameworkCore;
using ParcelDesk.Api.Data;
using ParcelDesk.Api.DTOs.Dashboard;
using ParcelDesk.Api.Models;

namespace ParcelDesk.Api.Services;

public class DashboardService
{
    private readonly ParcelDbContext _dbContext;

    public DashboardService(ParcelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DashboardSummaryResponse> GetSummaryAsync()
    {
        var totalShipments = await _dbContext.Shipments.CountAsync();

        var created = await _dbContext.Shipments.CountAsync(shipment => shipment.Status == ShipmentStatus.Created);

        var pickedUp = await _dbContext.Shipments.CountAsync(shipment => shipment.Status == ShipmentStatus.PickedUp);

        var inTransit = await _dbContext.Shipments.CountAsync(shipment => shipment.Status == ShipmentStatus.InTransit);

        var delivered = await _dbContext.Shipments.CountAsync(shipment => shipment.Status == ShipmentStatus.Delivered);

        var cancelled = await _dbContext.Shipments.CountAsync(shipment => shipment.Status == ShipmentStatus.Cancelled);

        return new DashboardSummaryResponse
        {
            TotalShipments = totalShipments,
            Created = created,  
            PickedUp = pickedUp,
            InTransit = inTransit,
            Delivered = delivered,
            Cancelled = cancelled
        };
    }
}