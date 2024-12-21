# BlogSystem Web API

BlogSystem is a web API developed using .NET 9, following industry-standard practices such as Domain-Driven Design (DDD), Clean Architecture, Vertical Slice Architecture, and CQRS. The system is designed for scalability, maintainability, and clarity.

## Features
- **Modular Architecture**: Domain-Driven Design (DDD), Clean Architecture, Vertical Slice Architecture.
- **CQRS (Command Query Responsibility Segregation)** for optimized read and write performance.
- **Docker Compose** for containerization and consistent environments across development, staging, and production.
- **CI/CD with GitHub Actions** for automated testing, building, and deployment.
- **Swagger Integration** for API documentation.
- **Unit Tests** to ensure the correctness of the core business logic.

## Prerequisites

Before you start, ensure you have the following installed:

- [Docker](https://www.docker.com/get-started)
- [Make](https://www.gnu.org/software/make/)
- [Git](https://git-scm.com/)
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Getting Started

### Clone the repository

Clone the repository to your local machine using Git:

```bash
git clone https://github.com/mostafaabbasi/BlogSystem
cd BlogSystem
```

### Setup certificate

Run these commands to allow the certificates to be properly exported and mounted.

```bash
# Create the directory first in the main root of the project.
mkdir $env:APPDATA\ASP.NET\Https

# Now export the certificate
dotnet dev-certs https --clean
dotnet dev-certs https -ep $env:APPDATA\ASP.NET\Https\aspnetapp.pfx -p password123
dotnet dev-certs https --trust
```

Run docker compose

```bash
make up
```

## Now you have access to these urls:
- **https://localhost:7168/swagger/index.html**
- **http://localhost:5193/swagger/index.html**