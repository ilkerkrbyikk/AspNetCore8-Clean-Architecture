using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.AsNoTracking().ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetById(int id)
    {
        var restaurant = await dbContext.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }
}
