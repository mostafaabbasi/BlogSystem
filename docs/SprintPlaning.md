# Sprint Planning

## Sprint 1: Initial Setup and Basic Domain Implementation

### Goals
- Set up the project structure
- Implement basic domain entities and value objects

### Tasks
- [x] Set up project structure
- [x] Implement `Entity` and `ValueObject` abstractions
- [x] Implement `PostId`, `Author`, `Content`, `Summary`, `Title`, `TagId`, and `Name` value objects
- [x] Implement `Tag` and `Post` entities

### Results
- Project structure established
- Basic domain entities and value objects implemented

## Sprint 2: Infrastructure Layer and Database Configuration

### Goals
- Implement infrastructure layer for posts and tags
- Configure database context and entity configurations
- Create initial migrations

### Tasks
- [x] Implement `PostConfiguration` and `TagConfiguration`
- [x] Implement `PostTags` table in `PostConfiguration`
- [x] Implement `PostRepository` and `TagRepository` 
- [x] Configure `BlogDbContext`
- [x] Configure `SqlConnecionFactory` to use `Dapper`
- [x] Create and apply initial migration

### Results
- Infrastructure layer for posts and tags implemented
- Database context and entity configurations set up
- Migrations created and applied
  
## Sprint 3: Application Layer and API Setup

### Goals
- Implement application layer
- Set up minimal API endpoints
- Create unit tests for domain entities

### Tasks
- [x] Implement `CQRS Pattern` in the application layer
- [x] Set up `BlogSystem.API` project
- [x] Implement `Program.cs` and `Startup.cs`
- [x] Implement minimal APIs
- [x] Write unit tests for domain entities

### Results
- Application layer by CQRS pattern implemented
- API project set up with minimal API endpoints
- Unit tests for domain entities created and passing



## Sprint 4: Testing, Refinement, and Dockerization

### Goals
- Refine and optimize codebase
- Ensure comprehensive test coverage
- Dockerize the application for deployment

### Tasks
- [x] Refine and optimize domain, application, and infrastructure layers
- [x] Set up Dockerfile and docker compose for the project
- [x] Set up CI on github

### Results
- Codebase refined and optimized
- Application dockerized and ready for deployment
- CI configuration implemented