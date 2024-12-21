using BlogSystem.API.Filters;

namespace BlogSystem.API.Extensions;

public static class ValidatorExtensions
{
    public static RouteHandlerBuilder Validator<T>(this RouteHandlerBuilder handlerBuilder)
        where T : class
    {
        handlerBuilder.AddEndpointFilter<EndpointValidatorFilter<T>>();
        return handlerBuilder;
    }
}