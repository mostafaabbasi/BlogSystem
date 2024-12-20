using BlogSystem.API.Abstractions;
using BlogSystem.API.Extensions;
using BlogSystem.Application.Posts.GetPostsByTagName;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.API.Endpoints.Posts.GetByTagName;

public sealed class GetPostsByTagNameEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/by-tag-name",
        async (
        [AsParameters] GetPostsByTagNameRequest parameter,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
            =>
        {
            return await mediator.Send(new GetPostsByTagNameQuery(parameter.TagName), cancellationToken);
        })
        .Validator<GetPostsByTagNameRequest>()
        .WithTags(EndpointSchema.PostSchema);
    }
}