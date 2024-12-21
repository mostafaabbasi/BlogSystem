using BlogSystem.API.Abstractions;
using BlogSystem.API.Extensions;
using BlogSystem.Application.Posts.CreatePost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.API.Endpoints.Posts.Create;

public sealed class CreatePostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/posts", async (
            [FromBody] CreatePostRequest body,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) => await mediator.Send(new CreatePostCommand(
                body.Title,
                body.Content,
                body.Summary,
                body.Author,
                body.TagNames), cancellationToken))
        .Validator<CreatePostRequest>()
        .WithTags(EndpointSchema.PostSchema);
    }
}