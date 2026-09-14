using System.ComponentModel.DataAnnotations;

namespace ParcelDesk.Api.Models;

public class Shipment
{
    public int Id {get; set;}

    [Required]
    [MaxLength(32)]
    public string Awb {get; set;} = string.Empty;

    public int CustomerId {get; set;}

    [Required]
    [MaxLength(500)]
    public string SenderAddress {get; set;} = string.Empty;

    [Required]
    [MaxLength(500)]
    public string DestinationAddress {get; set;} = string.Empty;

    [Required]
    [MaxLength(100)]
    public string City {get; set;} = string.Empty;

    public decimal Weight {get; set;}

    public ShipmentStatus Status {get; set;} = ShipmentStatus.Created;

    public DateTime CreatedAtUtc {get; set;}

    public DateTime UpdatedAtUtc {get; set;}

    [MaxLength(1000)]
    public string? Notes {get; set;}

    public Customer Customer {get; set;} = null!;
}