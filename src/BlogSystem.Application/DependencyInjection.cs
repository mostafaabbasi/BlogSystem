using Microsoft.Extensions.DependencyInjection;

namespace BlogSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(act=>
        {
            act.Namespace = "BlogSystem.Mediator";
            act.ServiceLifetime = ServiceLifetime.Scoped;
        });

        return services;
    }
}