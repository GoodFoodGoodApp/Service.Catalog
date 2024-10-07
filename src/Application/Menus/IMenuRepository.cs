namespace CatalogApi.Application.Menus;

using Entities;
public interface IMenusRepository
{
    Task<List<Menu>> GetMenus(CancellationToken cancellationToken);
    Task<Menu> GetMenu(Guid menu_id, CancellationToken cancellationToken);

    Task<List<Menu>> GetMenusByRestaurant(Guid restaurant_id, CancellationToken cancellationToken);
}
