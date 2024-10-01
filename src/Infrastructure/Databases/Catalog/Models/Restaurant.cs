namespace CatalogApi.Infrastructure.Databases.Catalog.Models;

using System.ComponentModel.DataAnnotations.Schema;
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

    // Foreign keys
    [ForeignKey("City")]
    public Guid CityId { get; set; }

    public City City { get; init; }

}
