using MediatR;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantRepository.GetById(request.Id);

            if (restaurant == null)
                return false;

            await restaurantRepository.Delete(restaurant);
            return true;
        }

       
    }
}
