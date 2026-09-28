namespace ParcelDesk.WinForms.Models;

public class CreateShipmentRequest
{
    public int CustomerId { get; set; }
    public string SenderAddress { get; set; } = string.Empty;
    public string DestinationAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public string? Notes { get; set; }
}