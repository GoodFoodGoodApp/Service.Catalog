namespace CatalogApi.Infrastructure.Databases.Catalog.Mapping;

using AutoMapper;
using Application = Application.Localisation.Entities;
using Infrastructure = Models;

internal class RegionMappingProfile : Profile
{
    public RegionMappingProfile()
    {
        _ = this.CreateMap<Application.Region, Infrastructure.Region>()
            .ForMember(d => d.DateCreated, o => o.Ignore())
            .ForMember(d => d.DateModified, o => o.Ignore())
            .ForMember(d => d.Cities, o => o.Ignore())
            .ReverseMap();
    }
}

