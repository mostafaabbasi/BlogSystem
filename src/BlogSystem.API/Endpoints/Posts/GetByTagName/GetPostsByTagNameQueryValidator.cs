using FluentValidation;

namespace BlogSystem.API.Endpoints.Posts.GetByTagName;

internal sealed class GetPostsByTagNameRequestValidator : AbstractValidator<GetPostsByTagNameRequest>
{
    public GetPostsByTagNameRequestValidator()
    {
        RuleFor(f => f.TagName)
        .NotEmpty()
        .WithMessage("Tag name must has value");
    }
}