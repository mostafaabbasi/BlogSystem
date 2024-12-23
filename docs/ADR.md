# BlogSystem Web API - Architecture Decision Record

## Overview

The `BlogSystem` is a web API developed using **.NET 9** and follows industry-standard practices to ensure maintainability, scalability, and clarity in the design. The architecture leverages Domain-Driven Design (DDD), Clean Architecture, Vertical Slice Architecture, CQRS, and other best practices to create a modular and scalable system. The application uses **SQL** for database management, **Docker Compose** for containerization, and **GitHub Actions** for continuous integration and deployment (CI/CD).

## Architectural Decisions

### 1. **Domain-Driven Design (DDD)**

- The core business logic is encapsulated within domain entities, aggregates, and value objects.
- The domain model is rich, ensuring that business rules are well-defined and easily testable.

### 2. **Clean Architecture**

- Separation of concerns is maintained between the Domain, Application, Infrastructure, and API layers.
- The architecture is flexible and framework-agnostic, ensuring future-proofing against external changes.

### 3. **Vertical Slice Architecture**

- Features are organized into self-contained units (commands, queries, handlers, validators) for better modularity and ease of testing.
- Each slice is independent, allowing teams to work on features without overlapping responsibilities.

### 4. **CQRS (Command Query Responsibility Segregation)**

- **Commands** handle write operations (create, update, delete) using **Entity Framework (EF)**.
- **Queries** handle read operations using **Dapper**, which provides a lightweight, fast, and efficient method for querying the database.
- This separation of concerns improves performance, as **Dapper** is highly optimized for read-heavy operations, while **EF** is used for managing transactional consistency in write operations.

### 5. **Repository and Unit of Work**

- **Repositories** abstract data access, promoting flexibility and ease of testing.
- **Unit of Work** ensures consistency across multiple repositories in a single transaction, primarily used for command handling with **EF**.
- **Dapper** is used for executing queries that don’t require the overhead of Entity Framework's change tracking, making it ideal for complex read operations.

### 6. **Database: SQL**

- **SQL** is chosen as the database due to its maturity, reliability, and support for complex queries and transactions.
- The database schema is designed to support the business logic defined in the domain model, ensuring consistency and scalability.

### 7. **Containerization: Docker Compose**

- **Docker Compose** is used for defining and running multi-container Docker applications.
- It simplifies the deployment process by allowing the API and database containers to be defined and started with a single command.
- **Docker Compose** ensures that the development, staging, and production environments are consistent and easily reproducible.

### 8. **CI/CD: GitHub Actions**

- **GitHub Actions** is used for automating the build, testing, and deployment processes.
- The CI/CD pipeline ensures that code is automatically built, tested, and deployed when changes are pushed to the repository, enhancing collaboration and reducing manual intervention.
- The pipeline runs unit tests and deploys the application to the appropriate environment, ensuring that the latest changes are always integrated.

### 9. **Minimal API**

- Provides a lightweight approach to building API endpoints, reducing boilerplate code and ensuring high performance.
- Simplified routing and direct endpoint definitions enhance developer productivity.

### 10. **Fluent Validation**

- Centralized and reusable validation logic ensures consistent validation rules across the application.
- Validation is defined in the application layer and can be reused by multiple commands and queries.

### 11. **Swagger**

- **Swagger** is integrated for interactive API documentation, making it easier for developers and clients to understand and use the API.
- Auto-generates endpoint documentation, request/response schemas, and supports API versioning.

### 12. **Unit Tests**

- Unit tests are implemented to validate the core business logic, ensuring the correctness of the application.
- Tests cover command handlers, query handlers, and business rule validations.
- Unit tests help catch regressions, ensuring stability and correctness during code refactoring or feature additions.

## Advantages

- **Modularity:** Clean separation between features, layers, and concerns.
- **Maintainability:** Code is organized, making it easier to test, extend, and refactor.
- **Scalability:** CQRS allows optimized performance for both reads (via **Dapper**) and writes (via **EF**).
- **Performance:** **Dapper** is optimized for read-heavy operations, while **EF** provides a full-featured solution for complex write operations with transactional consistency.
- **Containerization:** **Docker Compose** ensures environment consistency and simplifies deployment across different stages (development, staging, production).
- **CI/CD Automation:** **GitHub Actions** automates testing, building, and deployment, ensuring a smooth and reliable delivery pipeline.
- **Testability:** Unit tests ensure that the application behaves as expected and helps in early bug detection.
- **Developer Experience:** Minimal API and Swagger enhance developer productivity and client collaboration.

## Challenges

- **Initial Complexity:** Setting up DDD, CQRS, and Clean Architecture may involve a steeper learning curve.
- **Tooling and Integration:** Requires careful integration of **Dapper**, **EF**, Fluent Validation, Swagger, unit testing tools, **Docker Compose**, and **GitHub Actions**.
- **Consistency:** Ensuring consistency between the data access layers (**Dapper** for queries and **EF** for commands) requires additional attention to detail.
- **Database Migration:** Managing database schema changes and migrations using **EF** in the context of a Dockerized environment requires careful handling.

## Alternatives Considered

1. **Use of EF for both Queries and Commands:**
   - Rejected due to performance concerns. **EF** is slower for read-heavy operations, and using it for queries could introduce unnecessary overhead.

2. **Use of Dapper for both Queries and Commands:**
   - Rejected for commands due to **Dapper's** lack of support for features like change tracking and complex entity relationships that **EF** provides for transactional consistency.

3. **Use of Kubernetes for Containerization:**
   - Rejected in favor of **Docker Compose** due to the simplicity and ease of setup. **Kubernetes** would be more suited for large-scale production environments.

4. **CI/CD Using Jenkins or GitLab CI:**
   - **GitHub Actions** was selected as it is native to the GitHub ecosystem, simplifies configuration, and is integrated directly with the repository.

## Conclusion

The decisions outlined in this document ensure that the `BlogSystem` is built using best practices for maintainability, scalability, and flexibility. By using **Dapper** for queries, **EF** for commands, **SQL** as the database, **Docker Compose** for containerization, and **GitHub Actions** for CI/CD, we optimize performance, streamline development and deployment, and ensure consistency across environments. The architecture facilitates modular development, ease of testing, and provides clear separation between concerns. With unit tests and other quality practices in place, the project is positioned for long-term success.


## Explanation:
- **https://drive.google.com/file/d/1yW477waKhXCHkZ_4b1J8hjoplzJR1ZVF/view?usp=sharing**
