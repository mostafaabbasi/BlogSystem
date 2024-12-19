using BlogSystem.Application.Data;
using BlogSystem.Domain.Abstractions;
using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using BlogSystem.Infrastructure.Abstractions;
using BlogSystem.Infrastructure.Posts;
using BlogSystem.Infrastructure.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSql(configuration)
        .AddRepositories()
        .AddDapper(configuration)
        .AddUnitOfWork();

        return services;
    }

    private static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration)
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

        return services;
    }

    private static IServiceCollection AddDapper(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BlogConnection");

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>()
            .AddScoped<ITagRepository, TagRepository>();

        return services;
    }


    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}