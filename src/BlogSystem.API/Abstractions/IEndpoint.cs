namespace BlogSystem.API.Abstractions;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}