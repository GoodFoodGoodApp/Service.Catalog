namespace CatalogApi.Application.Localisation.Queries.GetLocalisation;

using Entities;
using MediatR;

public class GetCitiesQuery : IRequest<List<City>>
{
}

public class GetRegionsQuery : IRequest<List<Region>>
{
}
