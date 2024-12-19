using BlogSystem.Domain.Abstractions;
using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using Mediator;

namespace BlogSystem.Application.Posts.CreatePost;

internal sealed class CreatePostHandler(
    IPostRepository postRepository,
    IUnitOfWork unitOfWork,
    ITagRepository tagRepository) : ICommandHandler<CreatePostCommand, Guid>
{
    public async ValueTask<Guid> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var tags = await tagRepository.SetTagsAsync(command.TagNames, cancellationToken);

        var post = Post.Create(
        command.Title,
        command.Content,
        command.Summary,
        command.Author,
        tags);

        await postRepository.AddAsync(post, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}