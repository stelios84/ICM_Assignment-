# ICMarkets WEB API .NET Developer Project

A RESTful API built with ASP.NET Core that follows Domain-Driven Design (DDD) and Clean Architecture principles to ensure scalability, maintainability, and separation of concern

# Overview 
The project fetches chain blocks from endpoints, stores them, and returns their request history ordered by most recent first

# Architecture 
Project is separated by 4 layers
- Domain
  - Domain Models(AR)
  - IRepositories (Repository Interfaces)
  - IUnitOfWork interface
  - Domain services are intended to handle operations that involve multiple aggregates and cannot naturally belong to a single aggregate. In this project, all business logic could be managed within individual aggregates, so no domain service was introduced.
  - Providers
    - For this project, ISourceProvider and IProviderFactory interfaces are defined in the Domain layer, with their implementations in Infrastructure.
    - Although these interfaces are not currently used within the domain, they are included to allow for future scenarios where a domain service might need to interact closely with fetching data from different providers.
- Infrastructure
   - Repository implementations
   - AppDBContext and UnitOfWork Implementation
   - Provider Implementations
   - Entities (database)
- Application
  - Commands
  - Command Handlers
  - Command Dispatcher 
  - Queries
  - Application Services
    - Can be used to orchestrate commands and queries. Controllers can either delegate work to application services or directly use the command dispatcher.
- ICWEBAPP(UI)
   - Controllers
     - Communicates with the Application layer to execute use cases, retrieve data, or persist changes.
   - Startup
 
  # How to Use This Project
    1. Clone the repository https://github.com/stelios84/ICM_Assignment-.git
    2. Open the solution in Visual Studio
       - Ensure that the API project (ICWEBAPP) is set as the startup project
    3. Choose to debug with Docker (Container - Swagger)
       - Browser will automatically open Swagger UI, where you can explore and test all available endpoints.
       
