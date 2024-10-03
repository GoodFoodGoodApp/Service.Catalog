namespace CatalogApi.Presentation.Endpoints;

using CatalogApi.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public static class ArtefactEndpoints
{
    public static WebApplication MapArtefactEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/artefact")
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithTags("artefact")
            .WithDescription("Lookup and Find Artefacts")
            .WithOpenApi();

        _ = root.MapGet("/", GetArtefact)
            .Produces<string>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all Artefacts")
            .WithDescription("\n    GET /artefact");

        return app;
    }

    public static async Task<IResult> GetArtefact([FromServices] IMediator mediator)
    {
        try
        {
            // Fake an await by using Task.FromResult to return a completed task with the desired string
            return await Task.FromResult(Results.Ok("Hello world"));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
