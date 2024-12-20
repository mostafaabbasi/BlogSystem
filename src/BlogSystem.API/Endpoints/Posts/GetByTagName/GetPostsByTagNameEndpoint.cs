using BlogSystem.API.Abstractions;
using BlogSystem.API.Extensions;
using BlogSystem.Application.Posts.GetPostsByTagName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.API.Endpoints.Posts.GetByTagName;

public sealed class GetPostsByTagNameEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/posts/by-tag-name",
        async (
        [AsParameters] GetPostsByTagNameRequest parameter,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
            => await mediator.Send(new GetPostsByTagNameQuery(parameter.TagName), cancellationToken))
        .Validator<GetPostsByTagNameRequest>()
        .WithTags(EndpointSchema.PostSchema);
    }
}