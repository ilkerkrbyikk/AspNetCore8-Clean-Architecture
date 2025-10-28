using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    internal class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
        IRestaurantRepository restaurantRepository,
        IMapper mapper) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Restaurants");
            var restaurants = await restaurantRepository.GetAllAsync();

            var resturantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return resturantsDtos;
        }
    }
}
