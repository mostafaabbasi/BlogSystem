namespace BlogSystem.Domain.Tags;

public interface ITagRepository
{
    Task<List<Tag>> SetTagsAsync(List<string> tagNames, CancellationToken cancellationToken = default);
}