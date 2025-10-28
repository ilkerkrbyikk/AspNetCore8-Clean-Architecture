using AutoMapper;
using MediatR;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, 
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantRepository.GetById(request.Id);
        if (restaurant == null)
            return false;

        mapper.Map(request, restaurant);

        //restaurant.Name = request.Name;
        //restaurant.Description = request.Description;
        //restaurant.HasDelivery = request.HasDelivery;

        await restaurantRepository.SaveChanges();
        return true;
    }
}
