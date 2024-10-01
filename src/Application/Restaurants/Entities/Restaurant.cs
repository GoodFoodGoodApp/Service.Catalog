namespace CatalogApi.Application.Restaurants.Entities;

using System;
using Application.Localisation.Entities;

public record Restaurant(Guid Id, string Name, string Description, string Address, string Email, string Phone, City City);
