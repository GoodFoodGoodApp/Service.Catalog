namespace CatalogApi.Application.Restaurants.Queries.GetRestaurants;

using System.Threading;
using System.Threading.Tasks;
using CatalogApi.Application.Restaurants.Entities;
using MediatR;

public class GetRestaurantsHandler(IRestaurantRepository repository) : IRequestHandler<GetRestaurantsQuery, List<Restaurant>>
{
    public async Task<List<Restaurant>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetRestaurants(cancellationToken);
    }
}
