namespace ParcelDesk.WinForms.Models;

public class ShipmentStatusHistory
{
    public int Id { get; set; }
    public int ShipmentId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime ChangedAtUtc { get; set; }
}
