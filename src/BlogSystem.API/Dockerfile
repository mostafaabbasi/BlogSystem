FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/BlogSystem.API/BlogSystem.API.csproj", "src/BlogSystem.API/"]
COPY ["src/BlogSystem.Infrastructure/BlogSystem.Infrastructure.csproj", "src/BlogSystem.Infrastructure/"]
COPY ["src/BlogSystem.Domain/BlogSystem.Domain.csproj", "src/BlogSystem.Domain/"]
COPY ["src/BlogSystem.Application/BlogSystem.Application.csproj", "src/BlogSystem.Application/"]
RUN dotnet restore "src/BlogSystem.API/BlogSystem.API.csproj"

COPY . .

# Run tests
FROM build AS test
WORKDIR /src
RUN dotnet test --no-restore

# Publish
FROM build AS publish
WORKDIR /src
RUN dotnet publish "src/BlogSystem.API/BlogSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogSystem.API.dll"]