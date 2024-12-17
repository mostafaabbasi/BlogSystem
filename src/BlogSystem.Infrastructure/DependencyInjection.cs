using BlogSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddSql(services, configuration);
        return services;
    }

    private static void AddSql(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(act =>
        {
            var connectionString = configuration.GetConnectionString("BlogConnection");
            act.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure();
                builder.MigrationsAssembly(typeof(BlogDbContext).Assembly);
            });
        });
    }
}