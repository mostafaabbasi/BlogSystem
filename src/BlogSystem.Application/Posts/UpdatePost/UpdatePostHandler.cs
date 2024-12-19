using BlogSystem.Domain.Abstractions;
using BlogSystem.Domain.Exceptions;
using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using Mediator;

namespace BlogSystem.Application.Posts.UpdatePost;

internal sealed class UpdatePostHandler(
    IPostRepository postRepository,
    IUnitOfWork unitOfWork,
    ITagRepository tagRepository) : ICommandHandler<UpdatePostCommand>
{
    public async ValueTask<Unit> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        await PrivateHandle(command, cancellationToken);
        return Unit.Value;
    }
    private async Task PrivateHandle(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var existingPost = await postRepository.GetByIdAsync(command.Id, cancellationToken);

        CheckPostIsExist(existingPost);

        var tags = await tagRepository.SetTagsAsync(command.TagNames, cancellationToken);
        var tagIds = tags.Select(s=>s.Id).ToList();

        existingPost!.Update(
            command.Title,
            command.Content,
            command.Summary,
            command.Author,
            tagIds);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private void CheckPostIsExist(Post? existingPost)
    {
        if (existingPost is null)
            throw new NotFoundException("Post with this id:{command.Id} did not found");
    }
}