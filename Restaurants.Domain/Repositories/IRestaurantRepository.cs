
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetById(int id);
    Task<int> Create(Restaurant entity);
    Task Delete(Restaurant entity);
    Task SaveChanges();

}
