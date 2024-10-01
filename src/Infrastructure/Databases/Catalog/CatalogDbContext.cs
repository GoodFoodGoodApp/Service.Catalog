namespace CatalogApi.Infrastructure.Databases.Catalog;

using System.Reflection;
using CatalogApi.Infrastructure.Databases.Catalog.Models;
using Microsoft.EntityFrameworkCore;

internal class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    //Add entities here as DBSets

    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
