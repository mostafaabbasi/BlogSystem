using FluentValidation;

namespace BlogSystem.API.Endpoints.Posts.SearchOnContent;

internal sealed class GetPostsBySearchOnContentRequestValidator : AbstractValidator<GetPostsBySearchOnContentRequest>
{
    public GetPostsBySearchOnContentRequestValidator()
    {
        RuleFor(f => f.SearchTerm)
        .NotEmpty()
        .WithMessage("Search term couldn't be empty")
        .MinimumLength(2)
        .WithMessage("Search term must has at least 2 characters");
    }
}