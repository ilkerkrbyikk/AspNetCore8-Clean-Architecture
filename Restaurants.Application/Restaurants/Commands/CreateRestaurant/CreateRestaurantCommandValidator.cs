using FluentValidation;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(dto => dto.Category)
                .NotEmpty().WithMessage("Category is required.");

        RuleFor(dto => dto.ContactMail)
            .EmailAddress()
            .WithMessage("Please provide a valid e-mail.");

        /*BURAYA HER DTO-REQUEST NESNESİ İÇİN VALIDASYON CLASSI VE KURALLARI YAZILABILIR BOKUNU CIKARMAMAK ICIN BIRAKTIM.*/
        /*SERVICE REGISTIRATIONU VAR. UNUTMA!!! */
    }
}

