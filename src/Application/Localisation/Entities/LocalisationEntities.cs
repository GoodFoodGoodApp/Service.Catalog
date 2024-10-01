namespace CatalogApi.Application.Localisation.Entities;

public record City(Guid Id, string Name, string PostalCode, Region Region);

public record Region(Guid Id, string Name, string Country);
