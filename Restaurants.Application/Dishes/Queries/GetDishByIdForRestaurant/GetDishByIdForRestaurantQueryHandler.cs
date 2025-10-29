
using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQueryHandler(IRestaurantRepository restaurantRepository,
    IMapper mapper) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetById(request.RestaurantId);

        //Restaurant null mu kontrol edilmeli. Result Pattern kullanmıyorum exception da fırlatmak istemiyorum şimdilik.

        var dish = restaurant?.Dishes.FirstOrDefault(d => d.Id == request.DishId);

        //Dish null mu kontrol edilmeli. Result Pattern kullanmıyorum exception da fırlatmak istemiyorum şimdilik.

        var result = mapper.Map<DishDto>(dish);
        return result;
    }
}
