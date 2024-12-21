using BlogSystem.Domain.Abstractions;
using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using MediatR;

namespace BlogSystem.Application.Posts.CreatePost;

internal sealed class CreatePostHandler(
    IPostRepository postRepository,
    IUnitOfWork unitOfWork,
    ITagRepository tagRepository) : IRequestHandler<CreatePostCommand, Guid>
{
    public async Task<Guid> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var tags = await tagRepository.SetTagsAsync(command.TagNames, cancellationToken);
        var tagIds = tags.Select(s=>s.Id).ToList();

        var post = Post.Create(
        command.Title,
        command.Content,
        command.Summary,
        command.Author,
        tagIds);

        await postRepository.AddAsync(post, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post.Id.Value;
    }
}