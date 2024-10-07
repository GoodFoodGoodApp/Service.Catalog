namespace CatalogApi.Infrastructure.Databases.Catalog.Models;

using System.ComponentModel.DataAnnotations.Schema;

internal record MenuRestaurant : Entity
{
    [ForeignKey("Menu")]
    public Guid MenuId { get; set; }

    public Menu Menu { get; init; }

    [ForeignKey("Restaurant")]
    public Guid RestaurantId { get; set; }

    public Restaurant Restaurant { get; set; }

    public int Quantity { get; set; }
}
