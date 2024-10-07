namespace CatalogApi.Infrastructure.Databases.Catalog.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

internal class RegionConfiguration : EntityConfiguration<Region>
{
    public override void Configure(EntityTypeBuilder<Region> builder)
    {
        base.Configure(builder);

        _ = builder.HasMany(m => m.Cities).WithOne(c => c.Region).HasForeignKey(c => c.RegionId);
    }
}
