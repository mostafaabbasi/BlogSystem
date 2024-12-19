using BlogSystem.Domain.Tags;
using BlogSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Infrastructure.Repositories;

internal sealed class TagRepository(BlogDbContext dbContext) : ITagRepository
{
    private readonly DbSet<Tag> _entities = dbContext.Tags;

    public async Task<List<Tag>> SetTagsAsync(List<string> tagNames, CancellationToken cancellationToken = default)
    {
        if (!tagNames.Any()) return new();

        var existingTags = await GetTagsByNames(tagNames, cancellationToken);
        var existingTagNames = existingTags.Select(t => t.Name.Value).ToList();

        var newTagNames = tagNames.Except(existingTagNames).ToList();
        var newTags = newTagNames.Select(name => Tag.Create(new Name(name))).ToList();

        await _entities.AddRangeAsync(newTags, cancellationToken);

        return existingTags.Concat(newTags).ToList();
    }

    private async Task<List<Tag>> GetTagsByNames(List<string> tagNames, CancellationToken cancellationToken = default)
    {
        return await _entities.Where(w => tagNames.Contains(w.Name.Value)).ToListAsync(cancellationToken);
    }
}