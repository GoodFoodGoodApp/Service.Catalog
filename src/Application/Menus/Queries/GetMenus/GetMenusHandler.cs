namespace CatalogApi.Application.Menus.Queries.GetMenus;
using MediatR;
using Entities;

public class GetMenusHandler(IMenusRepository repository) : IRequestHandler<GetMenusQuery, List<Menu>>
{

    public async Task<List<Menu>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetMenus(cancellationToken);
    }
}
