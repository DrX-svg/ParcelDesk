namespace ParcelDesk.WinForms.Models;

public class HealthResponse
{
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset TimestampUtc { get; set; }
}