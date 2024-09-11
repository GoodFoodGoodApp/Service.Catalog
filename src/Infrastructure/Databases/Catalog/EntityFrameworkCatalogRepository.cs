namespace CatalogApi.Infrastructure.Databases.Catalog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CatalogApi.Application.Localisation;
using CatalogApi.Infrastructure.Databases.Catalog.Extensions;
using ApplicationCity = Application.Localisation.Entities.City;
using ApplicationRegion = Application.Localisation.Entities.Region;

internal class EntityFrameworkCatalogRepository : ILocalisationRepository
{

    private readonly CatalogDbContext context;
    private readonly TimeProvider timeProvider;
    private readonly IMapper mapper;

    public EntityFrameworkCatalogRepository(
        CatalogDbContext context,
        TimeProvider timeProvider,
        IMapper mapper)
    {
        this.context = context;
        this.timeProvider = timeProvider;
        this.mapper = mapper;

        if (this.context != null)
        {
            _ = this.context.Database.EnsureDeleted();
            _ = this.context.Database.EnsureCreated();
            _ = this.context.AddData();
        }
    }

    #region Regions
    public virtual async Task<List<ApplicationRegion>> GetRegions(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Cities
    public virtual async Task<List<ApplicationCity>> GetCities(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Restaurants
    #endregion

}
