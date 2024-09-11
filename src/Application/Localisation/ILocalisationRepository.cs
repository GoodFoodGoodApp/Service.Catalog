namespace CatalogApi.Application.Localisation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

public interface ILocalisationRepository
{
    Task<List<City>> GetCities(CancellationToken cancellationToken);
    Task<List<Region>> GetRegions(CancellationToken cancellationToken);
}
