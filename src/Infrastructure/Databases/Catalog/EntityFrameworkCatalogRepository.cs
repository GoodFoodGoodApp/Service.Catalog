namespace CatalogApi.Infrastructure.Databases.Catalog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CatalogApi.Application.Localisation;
using CatalogApi.Application.Menus;
using CatalogApi.Application.Menus.Entities;
using CatalogApi.Application.Restaurants;
using CatalogApi.Infrastructure.Databases.Catalog.Extensions;
using Microsoft.EntityFrameworkCore;
using ApplicationCity = Application.Localisation.Entities.City;
using ApplicationRegion = Application.Localisation.Entities.Region;
using ApplicationRestaurant = Application.Restaurants.Entities.Restaurant;

internal class EntityFrameworkCatalogRepository : ILocalisationRepository, IRestaurantRepository, IMenusRepository
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
        var results = await this.context.Regions
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return this.mapper.Map<List<ApplicationRegion>>(results);
    }

    #endregion

    #region Cities
    public virtual async Task<List<ApplicationCity>> GetCities(CancellationToken cancellationToken)
    {
        var results = await this.context.Cities
            .Include(c => c.Region)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return this.mapper.Map<List<ApplicationCity>>(results);
    }


    #endregion

    #region Restaurants

    public virtual async Task<List<ApplicationRestaurant>> GetRestaurants(CancellationToken cancellationToken)
    {
        var results = await this.context.Restaurants
            .Include(r => r.City)
            .Include(r => r.City.Region)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return this.mapper.Map<List<ApplicationRestaurant>>(results);

    }


    #endregion

    #region Menus
    public async Task<List<Menu>> GetMenus(CancellationToken cancellationToken)
    {
        var results = await this.context.Menus
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return this.mapper.Map<List<Menu>>(results);
    }

    public Task<Menu> GetMenu(Guid restaurant_id, CancellationToken cancellationToken)
    {
        //TODO add include to resturant in menu's model
        //var result = this.context.Menus
        //    .AsNoTracking()
        //    .FirstOrDefaultAsync(m => m.RestaurantId == restaurant_id, cancellationToken);

        throw new NotImplementedException();
    }

    #endregion
}
