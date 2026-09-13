using System.ComponentModel.DataAnnotations;

namespace ParcelDesk.Api.DTOs.Customers;

public class UpdateCustomerRequest
{
    [Required]
    [MaxLength(150)]
    public string Name{get; set;} = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Phone{get; set;} = string.Empty;

    [EmailAddress]
    [MaxLength(254)]
    public string? Email{get; set;}

    [Required]
    [MaxLength(500)]
    public string Address{get; set;} = string.Empty;
}