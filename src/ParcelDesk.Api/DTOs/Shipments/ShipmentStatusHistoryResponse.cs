namespace ParcelDesk.Api.DTOs.Shipments;

public class ShipmentStatusHistoryResponse
{
    public int Id { get; set; }

    public int ShipmentId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime ChangedAtUtc { get; set; }
}