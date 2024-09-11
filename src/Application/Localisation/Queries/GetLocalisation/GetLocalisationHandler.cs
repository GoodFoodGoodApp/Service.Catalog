namespace CatalogApi.Application.Localisation.Queries.GetLocalisation;

using System.Threading;
using System.Threading.Tasks;
using CatalogApi.Application.Localisation.Entities;
using MediatR;

public class GetCitiesHandler(ILocalisationRepository repository) : IRequestHandler<GetCitiesQuery, List<City>>
{
    public async Task<List<City>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetCities(cancellationToken);
    }

}
public class GetRegionsHandler(ILocalisationRepository repository) : IRequestHandler<GetRegionsQuery, List<Region>>
{
    public async Task<List<Region>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetRegions(cancellationToken);
    }
}
