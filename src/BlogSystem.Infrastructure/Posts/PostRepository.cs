using BlogSystem.Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Infrastructure.Posts;

internal sealed class PostRepository(BlogDbContext dbContext) : IPostRepository
{
    private readonly DbSet<Post> _entities = dbContext.Posts;

    public async Task AddAsync(Post entity, CancellationToken cancellationToken = default)
    {
        await _entities.AddAsync(entity, cancellationToken);
    }

    public async Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entities.Include(i => i.PostTags).FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
    }
}