namespace CatalogApi.Application.Restaurants.Queries.GetRestaurants;

using Entities;
using MediatR;

public class GetRestaurantsQuery : IRequest<List<Restaurant>>
{
}
