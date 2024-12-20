using BlogSystem.API.Abstractions;
using BlogSystem.API.Extensions;
using BlogSystem.Application.Posts.UpdatePost;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.API.Endpoints.Posts.Update;

public sealed class UpdatePostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/posts/{id}", async (
            [FromRoute] string id,
            [FromBody] UpdatePostRequest body,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            return await mediator.Send(new UpdatePostCommand(
                Guid.Parse(id),
                body.Title,
                body.Content,
                body.Summary,
                body.Author,
                body.TagNames), cancellationToken);
        })
        .Validator<UpdatePostRequest>()
        .WithTags(EndpointSchema.PostSchema);
    }
}