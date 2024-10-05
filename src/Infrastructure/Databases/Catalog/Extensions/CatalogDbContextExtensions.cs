namespace CatalogApi.Infrastructure.Databases.Catalog.Extensions;

using Bogus;
using Models;

internal static class CatalogDbContextExtensions
{

    // Populate fake data with Bogus/Faker
    // This is a simple example, in a real-world scenario, you would have more complex data

    /** HOW TO USE FAKER
     * 1. Create a new instance of Faker<T> where T is the type of the entity you want to generate data for
     * 2. Add rules to the Faker instance to define how the data should be generated (check here for nomenclature : https://github.com/bchavez/Bogus?tab=readme-ov-file#bogus-api-support)
     * 3. Generate the data using the Generate method (with number of items)
     * 4. Add the generated data to the context using the AddRange method
     * 5. Return the context
     * **/

    public static CatalogDbContext AddData(this CatalogDbContext context)
    {
        var regions = new Faker<Region>()
            .RuleFor(r => r.Id, f => Guid.NewGuid())
            .RuleFor(r => r.Name, f => f.Address.County())
            .RuleFor(r => r.Country, f => f.Address.Country())
            .Generate(5);

        context.AddRange(regions);

        var cities = new Faker<City>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Address.City())
            .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
            .RuleFor(c => c.RegionId, f => f.PickRandom(regions).Id)
            .Generate(10);

        context.AddRange(cities);

        var restaurants = new Faker<Restaurant>()
            .RuleFor(r => r.Name, f => f.Company.CompanyName())
            .RuleFor(r => r.Description, f => f.Lorem.Sentence())
            .RuleFor(r => r.Address, f => f.Address.FullAddress())
            .RuleFor(r => r.Email, f => f.Internet.Email())
            .RuleFor(r => r.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(r => r.CityId, f => f.PickRandom(cities).Id)
            .Generate(15);

        context.AddRange(restaurants);

        var menus = new Faker<Menu>()
            .RuleFor(m => m.Id, f => Guid.NewGuid())
            .RuleFor(m => m.Name, f => f.Commerce.ProductName())
            .RuleFor(m => m.Description, f => f.Lorem.Sentence())
            .RuleFor(m => m.Price, f => f.Finance.Amount(10, 50))
            .RuleFor(m => m.Picture, f => f.Image.PicsumUrl())
            .Generate(50);

        context.AddRange(menus);

        //Save and return the context

        _ = context.SaveChanges();

        return context;
    }
}
