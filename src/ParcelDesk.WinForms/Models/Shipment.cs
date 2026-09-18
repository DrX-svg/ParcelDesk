namespace ParcelDesk.WinForms.Models;

public class Shipment
{
    public int Id { get; set; }
    public string Awb { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string SenderAddress { get; set; } = string.Empty;
    public string DestinationAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
    public string? Notes { get; set; }
}