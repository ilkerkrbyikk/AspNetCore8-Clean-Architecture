

using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

public class RestaurantService(IRestaurantRepository restaurantRepository, 
    ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        logger.LogInformation("Getting All Restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetById(int id)
    {
        var restaurant = await restaurantRepository.GetById(id);
        return restaurant;
    }
}
