using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Infrastructure.Abstractions;

internal sealed class UnitOfWork(BlogDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}