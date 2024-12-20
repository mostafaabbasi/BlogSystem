using Mediator;

namespace BlogSystem.Application.Posts.CreatePost;

public sealed record CreatePostCommand(
    string Title,
    string Content,
    string Summary,
    string Author,
    List<string> TagNames) : ICommand<Guid>;