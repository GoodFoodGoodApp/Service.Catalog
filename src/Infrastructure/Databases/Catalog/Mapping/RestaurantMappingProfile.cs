namespace CatalogApi.Infrastructure.Databases.Catalog.Mapping;

using AutoMapper;
using Application = Application.Restaurants.Entities;
using Infrastructure = Models;

internal class RestaurantMappingProfile : Profile
{
    public RestaurantMappingProfile()
    {
        _ = this.CreateMap<Application.Restaurant, Infrastructure.Restaurant>()
            .ForMember(d => d.DateCreated, o => o.Ignore())
            .ForMember(d => d.DateModified, o => o.Ignore())
            .ForMember(d => d.CityId, o => o.Ignore())
            .ForMember(d => d.City, o => o.MapFrom(s => s.City))
            .ReverseMap();
    }
}

