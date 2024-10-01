namespace CatalogApi.Infrastructure.Databases.Catalog.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
internal record City : Entity
{
    public string Name { get; set; }
    public string PostalCode { get; set; }

    // Foreign keys
    [ForeignKey("Region")]
    public Guid RegionId { get; set; }

    public Region Region { get; init; }
}
