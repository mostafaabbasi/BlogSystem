using FluentValidation;

namespace BlogSystem.Application.Posts.GetPostsBySearchOnContent;

internal sealed class GetPostsBySearchOnContentQueryValidator : AbstractValidator<GetPostsBySearchOnContentQuery>
{
    public GetPostsBySearchOnContentQueryValidator()
    {
        RuleFor(f => f.SearchTerm)
        .NotEmpty()
        .WithMessage("Search term couldn't be empty")
        .MinimumLength(2)
        .WithMessage("Search term must has at least 2 characters");
    }
}