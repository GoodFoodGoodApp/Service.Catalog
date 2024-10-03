# How To : prise en main du template


## Couche Présentation

1. Créer un nouvel endpoint

Couche qui porte les endpoints de l'API REST via les classes ```ArtefactEndPoints.cs``` dans le dossier ```.\src\Presentation\Endpoints\``` .
  
Créer la nouvelle classe ```ArtefactEndpoints.cs``` et récupérer le contenu d'un endpoint similaire.

Configurer le constructeur  ```MapArtefactEndpoints``` de la classe pour définir le endpoint : 
```csharp
var root = app.MapGroup("/api/Artefact")
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithTags("artefact")
            .WithDescription("artefact")
            .WithOpenApi();
```
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

Au lancement de swagger, le nouvel endpoint doit être visible et opérationnel.

## Couche Application

## Couche Infrastructure
