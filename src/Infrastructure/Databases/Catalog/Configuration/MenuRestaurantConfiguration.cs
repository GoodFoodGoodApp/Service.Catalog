namespace CatalogApi.Infrastructure.Databases.Catalog.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

internal class MenuRestaurantConfiguration : EntityConfiguration<MenuRestaurant>
{
    public override void Configure(EntityTypeBuilder<MenuRestaurant> builder)
    {
        base.Configure(builder);

        // Key and relationships
        _ = builder.HasKey(mr => new { mr.MenuId, mr.RestaurantId });

        _ = builder.HasOne(mr => mr.Menu).WithMany(m => m.MenuRestaurants).HasForeignKey(mr => mr.MenuId);
        _ = builder.HasOne(mr => mr.Restaurant).WithMany(r => r.MenuRestaurants).HasForeignKey(mr => mr.RestaurantId);

        // Indexes
        _ = builder.HasIndex(mr => mr.MenuId);
        _ = builder.HasIndex(mr => mr.RestaurantId);
    }
}
