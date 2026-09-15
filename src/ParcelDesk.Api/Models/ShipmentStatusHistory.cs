namespace ParcelDesk.Api.Models;

public class ShipmentStatusHistory
{
    public int Id { get; set; }

    public int ShipmentId { get; set;}

    public ShipmentStatus Status { get; set; }

    public DateTime ChangedAtUtc { get; set; }

    public Shipment Shipment { get; set; } = null!;
}