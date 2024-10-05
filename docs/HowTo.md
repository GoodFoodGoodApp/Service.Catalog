# How To : prise en main du template


## Couche Présentation

1. Créer une nouvelle route

_Une route est ici intitulée Endpoints_ En général , une route est un chemin qui permet de définir un __ensemble de ressources__. Un endpoint est une __ressource accessible__ via une URL et une méthode HTTP.

La couche présentation porte les endpoints de l'API REST via les classes ```ArtefactEndPoints.cs``` dans le dossier ```.\src\Presentation\Endpoints\``` .
  
Créer la nouvelle classe ```ArtefactEndpoints.cs``` et récupérer le contenu d'une ressource similaire.

Configurer le constructeur  ```MapArtefactEndpoints``` de la classe pour définir la route : 
```csharp
var root = app.MapGroup("/api/Artefact")
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithTags("artefact")
            .WithDescription("artefact")
            .WithOpenApi();
```

2. Créer un nouvel endpoint GET

Dans un premier temps créer un endpoint en __GET__, avec un retour de type string tel que :

````csharp
    public static async Task<IResult> GetArtefact([FromServices] IMediator mediator)
    {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
    }
````


Configurer le constructeur pour répertorier le endpoint spécifié au-dessus (à placer en dessous du _var root_ : 
```csharp
_ = root.MapGet("/", GetArtefact)
    .Produces<string>()
    .ProducesProblem(StatusCodes.Status500InternalServerError)
    .WithSummary("Artefact")
    .WithDescription("\n    GET /artefact");
```

Points d'attention :
- L'intitulé du namespace
- L'intitulé de la classe / constructeur
- L'intitulé des _using_

2. Ajouter ce nouvel endpoint

Dans le fichier ```.\src\Presentation\Extensions\WebApplicationExtensions.cs``` dans la ```region Minimal API``` ajouter le nouvel endpoint tel que
 de la couche 
```csharp
  _ = app.MapArtefactEndpoints();
``` 

Au lancement de swagger, la route et son endpoint doivent être visibles et opérationnels.

## Couche Application

La couche application porte les services, les règles métiers, les aggrégations etc. Ici elle fonctionne à partir de la définition des objets __Entity__ et implémente le pattern __CQRS__. Elle porte l'interface qui va permettre de communiquer avec la couche Infrastructure via le repository __IArtefactRepository__.

1. Créer un nouveau dossier qui porte le nom de l'objet métier / du domaine ```Artefact``` dans le dossier ```.\src\Application\Artefact\```

2. Créer les dossiers ```Entities``` ```Commands``` et ```Queries``` dans le dossier ```.\src\Application\Artefact\```

3. Créer l'interface ```IArtefactRepository``` dans le dossier ```.\src\Application\Artefact\```

4. Dans l'interface créer les premières fonctions tel que {#IRepository}    
  ```csharp
  public IArtefactsRepository
  {
  //Récupère un artefact par son id
    Task<Artefact> GetArtefact(Guid id, CancellationToken cancellationToken);

    //Récupère une liste de tous les artefacts
    Task<List<Artefact>> GetArtefacts( CancellationToken cancellationToken);
  }
  ```

## Couche Infrastructure
 
 La couche infrastructure porte les services qui permettent de communiquer avec les bases de données, les fichiers, les services externes etc. Elle implémente les interfaces de la couche Application.

 1. Créer le modèle (Plain Object)

Créer le modèle ```Artefact.cs``` dans le dossier ```.\src\Infrastructure\Databases\Catalog\Models\```
 Le modèle est un _record_ de portée _internal_ qui hérite de _Entity_.
 ```csharp
 [ExcludeFromCodeCoverage]
internal record Menu : Entity
{
// ajout des propriétés
}
 
 ```
   2. Déclarer ce modèle comme table dans le DBContext

   ```csharp
   public DbSet<Artefact> Artefacts { get; set; }
   ```

3. Implémenter l'interface dans la classe repository

Dans la classe ```.\src\Infrastructure\Databases\Catalog\EntityFrameworkCatalogRepository.cs```, le constructeur doit implémenter le repository ```IArtefactRepository```.

Les fonctions de l'interface doivent être implémentées dans ```IArtefactRepository```  :

```csharp
public async Task<List<Artefact>> GetArtefacts( CancellationToken cancellationToken)
{
    throw new NotImplementedException();
}
```

4. Configurer automapper pour ce modèle

Dans le dossier ```.\src\Infrastructure\Databases\Catalog\Mapping\``` créer une _internal class_ ```ArtefactMappingProfile``` héritant de _AutoMapper.Profile_. Cette classe aura la charge d'interpréter les objets entre les couches Application et Infrastructure.

!!! Pour faciliter le mapping puisque les classes portent des noms similaires importer les namespace des classes sous ce format :
```csharp
using Application = Application.Artfefacts.Entities;
using Infrastructure = Models;
```


  5. Ajouter le service dans le container de DI

  ```csharp 
  
        _ = services.AddSingleton<IArtefactsRepository>(p =>
                                 p.GetRequiredService<EntityFrameworkCatalogRepository>());
  ```



### Data faker

Pour tester les données via une bdd _in memory_ , il est possible de créer des données fictives via la librairie _Bogus_.

Dans la classe ```.\src\Infrastructure\Databases\Catalog\Extensions\CatalogDbContextExtensions.cs``` dans la méthode ```AddData``` :

```csharp
var artefacts = new Faker<Artefact>()
    .RuleFor(x => x.Id, f => f.Random.Guid())
    .RuleFor(x => x.Name, f => f.Random.String2(10))
    .Generate(10);

context.AddRange(artefacts);

```
