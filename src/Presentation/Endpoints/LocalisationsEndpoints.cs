namespace CatalogApi.Presentation.Endpoints;

using CatalogApi.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities = Application.Localisation.Entities;
using Queries = Application.Localisation.Queries;

public static class LocalisationsEndpoints
{
    public static WebApplication MapLocalisationsEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/localisation")
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithTags("localisation")
            .WithDescription("Lookup and Find Localisations")
            .WithOpenApi();

        _ = root.MapGet("/city", GetCities)
            .Produces<List<Entities.City>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all Cities")
            .WithDescription("\n    GET /localisation/city");

        _ = root.MapGet("/region", GetRegions)
            .Produces<List<Entities.Region>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all Regions")
            .WithDescription("\n    GET /localisation/region");

        return app;
    }

    public static async Task<IResult> GetCities([FromServices] IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetLocalisation.GetCitiesQuery()));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public static async Task<IResult> GetRegions([FromServices] IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetLocalisation.GetRegionsQuery()));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
