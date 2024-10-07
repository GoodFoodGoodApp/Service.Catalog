# Good food, good app

## Description
Catalog microservice for a food delivery application. This microservice is responsible for managing the catalog of food items available for order. It provides APIs for creating, updating, deleting, and retrieving food items, as well as searching for food items based on various criteria such as name, category, and price.


## Built With

Built from clean Minimal API template by [Stephen Walsh](https://github.com/stphnwlsh)
Available here: [Minimal API](https://github.com/stphnwlsh/CleanMinimalApi/)


## Features used

- Logging using [Serilog](https://github.com/serilog/serilog)
- Mediator Pattern using [Mediatr](https://github.com/jbogard/MediatR)
- Validation using [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- Testing using [Shouldly](https://github.com/shouldly/shouldly) and [NSubstitute](https://github.com/nsubstitute/NSubstitute)
- OpenApi using [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- Object Mapping using [AutoMapper](https://github.com/AutoMapper/AutoMapper)


## Launch with docker

When you're ready, start your application by running:
`docker compose up --build`.

Your application will be available at http://localhost:8080/swagger/index.html.

