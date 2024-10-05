namespace CatalogApi.Infrastructure;

using System;
using Application.Authors;
using Application.Movies;
using Application.Reviews;
using Application.Localisation;
using Databases.Catalog;
using Databases.MoviesReviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Restaurants;
using CatalogApi.Application.Menus;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        // Add base DBContext (Movies)
        _ = services.AddDbContext<MovieReviewsDbContext>(options =>
            options.UseInMemoryDatabase($"Movies-{Guid.NewGuid()}"), ServiceLifetime.Singleton);

        _ = services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        _ = services.AddSingleton<EntityFrameworkMovieReviewsRepository>();

        _ = services.AddSingleton<IAuthorsRepository>(p =>
            p.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IMoviesRepository>(x =>
            x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IReviewsRepository>(x =>
            x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());

        _ = services.AddSingleton(TimeProvider.System);


        // Add base DBContext (Catalog)

        _ = services.AddDbContext<CatalogDbContext>(options =>
                   options.UseInMemoryDatabase($"Catalog-{Guid.NewGuid()}"), ServiceLifetime.Singleton);
        _ = services.AddSingleton<EntityFrameworkCatalogRepository>();
        _ = services.AddSingleton<ILocalisationRepository>(p =>
                   p.GetRequiredService<EntityFrameworkCatalogRepository>());

        _ = services.AddSingleton<IRestaurantRepository>(p =>
                          p.GetRequiredService<EntityFrameworkCatalogRepository>());

        _ = services.AddSingleton<IMenusRepository>(p =>
                                 p.GetRequiredService<EntityFrameworkCatalogRepository>());

        return services;
    }
}
