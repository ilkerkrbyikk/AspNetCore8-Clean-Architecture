using AutoMapper;
using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler(IRestaurantRepository restaurantRepository,
        IDishesRepository dishesRepository,
        IMapper mapper) : IRequestHandler<CreateDishCommand>
    {
        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var restaurant = restaurantRepository.GetById(request.RestaurantId);

            //resturant null geldiği durumu kontrol etmiyorum.
            //normalde edilmeli result pattern uygulanıp controllera ve kullanıcıya biiglilendirilmeli!...

            var dish = mapper.Map<Dish>(request);
            await dishesRepository.Create(dish);
        }
    }
}
