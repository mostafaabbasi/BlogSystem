using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlogSystem.Infrastructure.Persistence;

public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<BlogDbContext>();

        optionBuilder.UseSqlServer("Server=localhost,1433;Database=Blog;User Id=SA;Password=SqLP@ass;TrustServerCertificate=True;MultipleActiveResultSets=true;");

        return new BlogDbContext(optionBuilder.Options);
    }
}