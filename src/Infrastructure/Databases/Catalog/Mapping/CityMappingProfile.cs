namespace CatalogApi.Infrastructure.Databases.Catalog.Mapping;

using AutoMapper;
using Application = Application.Localisation.Entities;
using Infrastructure = Models;

internal class CityMappingProfile : Profile {
    public CityMappingProfile()
    {
        _ = this.CreateMap<Application.City, Infrastructure.City>()
            .ForMember(d => d.DateCreated, o => o.Ignore())
            .ForMember(d => d.DateModified, o => o.Ignore())
            .ForMember(d => d.RegionId, o => o.Ignore())
            .ForMember(d => d.Region, o => o.MapFrom(s => s.Region))
            .ReverseMap();
    }
}

