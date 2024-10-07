namespace CatalogApi.Infrastructure.Databases.Catalog.Models;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
internal record Menu : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Picture { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<MenuRestaurant> MenuRestaurants { get; set; }
}
