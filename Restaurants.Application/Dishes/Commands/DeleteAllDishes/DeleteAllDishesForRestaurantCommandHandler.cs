

using MediatR;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteAllDishes;

public class DeleteAllDishesForRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
    IDishesRepository dishesRepository) : IRequestHandler<DeleteAllDishesForRestaurantCommand>
{
    public async Task Handle(DeleteAllDishesForRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetById(request.RestaurantId);

        //Restaurant null mu kontrol edilmeli. Result Pattern kullanmıyorum exception da fırlatmak istemiyorum şimdilik.

        await dishesRepository.Delete(restaurant.Dishes);
    }
}
