using FluentValidation;

namespace BlogSystem.Application.Posts.GetPostsByTagName;

internal sealed class GetPostsByTagNameQueryValidator : AbstractValidator<GetPostsByTagNameQuery>
{
    public GetPostsByTagNameQueryValidator()
    {
        RuleFor(f=>f.TagName)
        .NotEmpty()
        .WithMessage("Tag name must has value");
    }
}