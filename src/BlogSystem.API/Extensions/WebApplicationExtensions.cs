using BlogSystem.API.Abstractions;
using BlogSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.API.Extensions;

public static class WebApplicationExtensions
{
    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        IEnumerable<IEndpoint> endpoints = app.Services
            .GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }

        return app;
    }

    public static IApplicationBuilder ApplyMigrations(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();

        using BlogDbContext dbContext = scope.ServiceProvider.GetRequiredService<BlogDbContext>();

        dbContext.Database.Migrate();
    }
}