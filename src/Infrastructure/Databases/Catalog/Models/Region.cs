namespace CatalogApi.Infrastructure.Databases.Catalog.Models;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
internal record Region : Entity
{
    public string Name { get; set; }
    public string Country { get; set; }

    public ICollection<City> Cities { get; init; }
}
