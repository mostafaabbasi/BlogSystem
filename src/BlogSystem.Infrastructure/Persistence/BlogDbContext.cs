using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Infrastructure.Persistence;

public sealed class BlogDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}