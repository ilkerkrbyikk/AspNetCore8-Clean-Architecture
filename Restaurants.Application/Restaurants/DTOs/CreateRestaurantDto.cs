using System.ComponentModel.DataAnnotations;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Restaurants.DTOs;
public class CreateRestaurantDto
{
    /*DETAYLI VALIDATION ANNOTATION EKLEMEDIM UGRASMADIM FLUENT VALIDATIN DAHA MANTIKLI*/
    [StringLength(100,MinimumLength = 4)]
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }

    [EmailAddress(ErrorMessage = "Please provide a valid e-mail.")]
    public string? ContactMail { get; set; }

    [Phone(ErrorMessage = "Please provide a valid phone number.")]
    public string? ContactNumber { get; set; }

}
