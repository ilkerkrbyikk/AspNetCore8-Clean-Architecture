using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        //BURAYA VALIDATIONLAR YAZILIR. CASE'INE GORE YAZARSIN.
        RuleFor(x => x.Price)
            .GreaterThan(0);
 
        RuleFor(x => x.KiloCalories)
            .GreaterThanOrEqualTo(0)
            .When(x => x.KiloCalories.HasValue);
    }
}
