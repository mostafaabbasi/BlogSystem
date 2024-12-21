namespace BlogSystem.Domain.Posts;

public interface IPostRepository
{
    Task AddAsync(Post post, CancellationToken cancellationToken = default);
    Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}