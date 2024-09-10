namespace CatalogApi.Infrastructure.Databases.Catalog;
using System;
using AutoMapper;
using CatalogApi.Infrastructure.Databases.Catalog.Extensions;

internal class EntityFrameworkCatalogRepository
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

        #region Regions

        #endregion

        #region Cities
        #endregion

        #region Restaurants
        #endregion

    }
}
