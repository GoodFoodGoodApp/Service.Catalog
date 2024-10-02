namespace CatalogApi.Application.Menus.Queries.GetMenusByRestaurant;

using System.Collections.Generic;
using MediatR;
using CatalogApi.Application.Menus.Entities;
using System.ComponentModel.DataAnnotations;

public class GetMenusByRestaurantQuery : IRequest<List<Menu>>
{
    [Required]
    public Guid RestaurantId { get; init; }
}
