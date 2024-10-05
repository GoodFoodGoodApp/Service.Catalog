namespace CatalogApi.Infrastructure.Databases.Catalog.Mapping;

using AutoMapper;
using Application = Application.Menus.Entities;
using Infrastructure = Models;

internal class MenuMappingProfile : Profile
{
    public MenuMappingProfile()
    {
        _ = this.CreateMap<Application.Menu, Infrastructure.Menu>()
            .ForMember(d => d.DateCreated, o => o.Ignore())
            .ForMember(d => d.DateModified, o => o.Ignore())
            .ReverseMap();
    }
}
