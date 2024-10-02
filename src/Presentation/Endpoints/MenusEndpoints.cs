namespace CatalogApi.Presentation.Endpoints;

using CatalogApi.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Queries = Application.Menus.Queries;
using Entities = Application.Menus.Entities;

public static class MenusEndpoints
{

    public static WebApplication MapMenusEndpoints(this WebApplication app)
    {

        var root = app.MapGroup("/api/menu")
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithTags("menu")
            .WithDescription("Lookup and find menus")
            .WithOpenApi();

        _ = root.MapGet("", GetMenus)
            .Produces<List<Entities.Menu>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all menus")
            .WithDescription("\n    GET /menu");

        _ = root.MapGet("/{restaurant_id}", GetMenusByRestaurant)
            .Produces<Entities.Menu>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup a menu by restaurant")
            .WithDescription("\n    GET /menu/{restaurant_id}");

        return app;
    }

    public static async Task<IResult> GetMenus([FromServices] IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetMenus.GetMenusQuery()));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public static async Task<IResult> GetMenusByRestaurant([FromServices] IMediator mediator, Guid restaurant_id)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetMenusByRestaurant.GetMenusByRestaurantQuery { RestaurantId = restaurant_id}));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
