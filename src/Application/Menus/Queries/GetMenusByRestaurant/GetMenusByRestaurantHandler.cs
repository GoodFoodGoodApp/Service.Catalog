namespace CatalogApi.Application.Menus.Queries.GetMenusByRestaurant;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatalogApi.Application.Menus;
using CatalogApi.Application.Menus.Entities;
using MediatR;

public class GetMenusByRestaurantHandler(IMenusRepository repository) : IRequestHandler<GetMenusByRestaurantQuery, List<Menu>>
{
    public async Task<List<Menu>> Handle(GetMenusByRestaurantQuery request, CancellationToken cancellationToken)
    {
        // Implement the logic to retrieve menus by restaurant using the _menuRepository
        // Example:
        // var menus = await _menuRepository.GetMenusByRestaurant(request.RestaurantId);
        // return menus;

        // Placeholder return statement
        return new List<Menu>();
    }
}
