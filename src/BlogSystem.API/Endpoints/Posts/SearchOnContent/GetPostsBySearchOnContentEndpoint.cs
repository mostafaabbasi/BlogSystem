using BlogSystem.API.Abstractions;
using BlogSystem.API.Extensions;
using BlogSystem.Application.Posts.GetPostsBySearchOnContent;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.API.Endpoints.Posts.SearchOnContent;

public sealed class GetPostsBySearchOnContentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/search-on-content", async (
            [AsParameters] GetPostsBySearchOnContentRequest parameter,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            return await mediator.Send(new GetPostsBySearchOnContentQuery(parameter.SearchTerm), cancellationToken);
        })
        .Validator<GetPostsBySearchOnContentRequest>()
        .WithTags(EndpointSchema.PostSchema);
    }
}