using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;

public class GetDishesForRestaurantQueryHandler(IRestaurantRepository restaurantRepository,
    IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetById(request.RestaurantId);

        //Restaurant null mu kontrol edilmeli. Result Pattern kullanmıyorum exception da fırlatmak istemiyorum şimdilik.

        var results = mapper.Map<IEnumerable<DishDto>>(restaurant!.Dishes);

        return results;
    }
}
