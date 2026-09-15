using System.ComponentModel.DataAnnotations;
using ParcelDesk.Api.Models;

namespace ParcelDesk.Api.DTOs.Shipments;

public class UpdateShipmentStatusRequest
{
    [Required]
    public ShipmentStatus? Status { get; set; }
}