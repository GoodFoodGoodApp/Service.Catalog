namespace CatalogApi.Infrastructure.Databases.Catalog.Models;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
internal record Restaurant : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    // Add gps location

    // Keys

    public Guid CityId { get; set; }

}
