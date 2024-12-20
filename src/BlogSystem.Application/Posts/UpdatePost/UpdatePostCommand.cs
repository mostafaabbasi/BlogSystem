using MediatR;

namespace BlogSystem.Application.Posts.UpdatePost;

public sealed record UpdatePostCommand(
    Guid Id, 
    string Title, 
    string Content, 
    string Summary, 
    string Author,
    List<string> TagNames) : IRequest;