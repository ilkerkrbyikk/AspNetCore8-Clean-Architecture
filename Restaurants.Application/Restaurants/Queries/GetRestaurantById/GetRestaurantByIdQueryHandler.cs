using AutoMapper;
using MediatR;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetById(request.Id);
        var restourantDto = mapper.Map<RestaurantDto>(restaurant);
         
        return restourantDto;
    }
}
