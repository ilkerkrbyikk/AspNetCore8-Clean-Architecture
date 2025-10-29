using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteAllDishes;

public class DeleteAllDishesForRestaurantCommand(int restaurandId) : IRequest
{
    public int RestaurantId { get; } = restaurandId;
}
