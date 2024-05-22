# GameStore API Project Tasks

## Objective
The goal of this project is to build a GameStore API using .NET 8, with a focus on creating a CRUD (Create, Read, Update, Delete) system for managing game information. We'll use Entity Framework as the ORM for data storage.

## Tasks

### Setup Project and Solution
- Create a new .NET 8 project (e.g., ASP.NET Core Web API). ok
- Organize the solution with appropriate folders (Controllers, Services, Repositories, etc.). ok

### Model: Game
- Define the `Game` model class with properties such as `Id`, `Title`, `Genre`, `Platform`, `ReleaseDate`, `CreatedAt`. ok
- Configure the Entity Framework context to include the `Game` model. ok

### Database Setup
- Configure the database connection string in the `appsettings.json` file.
- Use Entity Framework migrations to create the database schema.

### Repository Pattern
- Create a repository interface (e.g., `IGameRepository`) with methods for CRUD operations related to games.
- Implement the repository class (e.g., `GameRepository`) that interacts with the database using Entity Framework.

### Dependency Injection
- Register the repository in the dependency injection container (e.g., in `Startup.cs`).
- Inject the repository into the game controller.

### Game Controller
- Create a controller (e.g., `GamesController`) with endpoints for CRUD operations.
- Implement actions for creating, retrieving, updating, and deleting games.
- Map the controller actions to appropriate HTTP methods and routes.

### Service Layer
- Create a service interface (e.g., `IGameService`) that defines methods for business logic related to games.
- Implement the service class (e.g., `GameService`) that uses the repository to perform CRUD operations.

### Validation and Error Handling
- Validate input data (e.g., required fields, valid dates) in the controller.
- Handle exceptions (e.g., not found, validation errors) and return appropriate HTTP status codes.

### API Documentation
- Use Swagger (OpenAPI) to document your API endpoints.
- Describe the available routes, request parameters, and response formats.    

### Unit Testing (OPTIONAL)
- Write unit tests for the repository, service, and controller.
- Use mocking frameworks (e.g., Moq) to isolate dependencies.

### Integration Testing (Optional)
- Test the entire API by making HTTP requests to endpoints.
- Verify that the API behaves correctly in a real-world scenario.

### Deployment and Hosting
- Choose a hosting platform (e.g., Azure, AWS, Heroku).
- Deploy your API to a production environment.

Remember to adapt these tasks to your specific project requirements. Good luck with your GameStore API development!
