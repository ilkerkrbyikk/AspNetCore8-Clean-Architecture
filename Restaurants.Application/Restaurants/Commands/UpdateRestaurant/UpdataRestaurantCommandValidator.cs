using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdataRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdataRestaurantCommandValidator()
    {
        RuleFor(c => c.Name)
            .Length(3, 100);

    }
}
