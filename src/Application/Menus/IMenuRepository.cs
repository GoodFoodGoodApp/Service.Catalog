namespace CatalogApi.Application.Menus;

using Entities;
public interface IMenusRepository
{
    Task<List<Menu>> GetMenus(CancellationToken cancellationToken);
    Task<Menu> GetMenu(Guid restaurant_id, CancellationToken cancellationToken);
}
