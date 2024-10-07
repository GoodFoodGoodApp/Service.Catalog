namespace CatalogApi.Infrastructure.Databases.Catalog.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

internal class RestaurantConfiguration : EntityConfiguration<Restaurant>
{
    public override void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        base.Configure(builder);

    }
}
