using BlogSystem.Application.Data;
using BlogSystem.Domain.Abstractions;
using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using BlogSystem.Infrastructure.Persistence;
using BlogSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddSql(services, configuration);
        AddRepositories(services);
        AddDapper(services, configuration);

        return services;
    }

    private static void AddSql(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IUnitOfWork,BlogDbContext>(act =>
        {
            var connectionString = configuration.GetConnectionString("BlogConnection");
            act.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure();
                builder.MigrationsAssembly(typeof(BlogDbContext).Assembly);
            });
        });
    }

    private static void AddDapper(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BlogConnection");

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>()
            .AddScoped<ITagRepository, TagRepository>();
    }
}