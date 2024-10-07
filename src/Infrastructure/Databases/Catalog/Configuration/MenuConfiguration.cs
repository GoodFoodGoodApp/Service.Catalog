namespace CatalogApi.Infrastructure.Databases.Catalog.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

internal class MenuConfiguration : EntityConfiguration<Menu>
{
    public override void Configure(EntityTypeBuilder<Menu> builder)
    {
        base.Configure(builder);

    }
}
