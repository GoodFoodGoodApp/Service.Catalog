namespace CatalogApi.Application.Restaurants;

using Entities;

public interface IRestaurantRepository
{

    Task<List<Restaurant>> GetRestaurants(CancellationToken cancellationToken);
}
