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

## Couche Infrastructure
