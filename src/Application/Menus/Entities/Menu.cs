namespace CatalogApi.Application.Menus.Entities;
using System;
using CatalogApi.Application.Restaurants.Entities;

public record Menu(Guid Id, string Name, string Description, decimal Price, Restaurant Restaurant);
