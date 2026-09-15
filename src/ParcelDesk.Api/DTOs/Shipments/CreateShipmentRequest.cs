using System.ComponentModel.DataAnnotations;

namespace ParcelDesk.Api.DTOs.Shipments;

public class CreateShipmentRequest
{
    [Range(1, int.MaxValue)]
    public int CustomerID {get; set;}

    [Required]
    [MaxLength(500)]
    public string SenderAddress {get; set;} = string.Empty;

    [Required]
    [MaxLength(500)]
    public string DestinationAddress {get; set;} = string.Empty;

    [Required]
    [MaxLength(100)]
    public string City {get; set;} = string.Empty;

    [Range(typeof(decimal), "0.01", "150.99")]
    public decimal Weight {get; set;}

    [MaxLength(1000)]
    public string? Notes {get; set;}
}