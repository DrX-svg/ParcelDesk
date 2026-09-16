using System.ComponentModel.DataAnnotations;
using ParcelDesk.Api.Models;

namespace ParcelDesk.Api.DTOs.Shipments;

public class ShipmentFilterRequest
{
    public ShipmentStatus? Status { get; set; }

    [Range(1, int.MaxValue)]
    public int? CustomerId { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? Search { get; set; }
}