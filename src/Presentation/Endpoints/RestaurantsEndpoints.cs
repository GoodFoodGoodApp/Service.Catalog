namespace CatalogApi.Presentation.Endpoints;

using CatalogApi.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Queries = Application.Restaurants.Queries;
using Entities = Application.Restaurants.Entities;

public static class RestaurantsEndpoints
{

    public static WebApplication MapRestaurantsEndpoints(this WebApplication app)
    {

        var root = app.MapGroup("/api/restaurant")
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithTags("restaurant")
            .WithDescription("Lookup and find restaurants")
            .WithOpenApi();

        _ = root.MapGet("", GetRestaurants)
            .Produces<List<Entities.Restaurant>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all restaurants")
            .WithDescription("\n    GET /restaurant");

        return app;
    }

    public static async Task<IResult> GetRestaurants([FromServices] IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetRestaurants.GetRestaurantsQuery()));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
