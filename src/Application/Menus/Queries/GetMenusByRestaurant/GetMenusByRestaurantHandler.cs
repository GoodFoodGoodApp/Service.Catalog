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
        return await repository.GetMenusByRestaurant(request.RestaurantId, cancellationToken);
    }
}
