using BlogSystem.API.Abstractions;
using BlogSystem.Application.Tags.GetTags;
using Mediator;

namespace BlogSystem.API.Endpoints.Tags.GetAll;

public sealed class GetAllTagsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/tags", async (IMediator mediator, CancellationToken cancellationToken) => 
            await mediator.Send(new GetTagsQuery(), cancellationToken))
        .WithTags(EndpointSchema.TagSchema);
    }
}