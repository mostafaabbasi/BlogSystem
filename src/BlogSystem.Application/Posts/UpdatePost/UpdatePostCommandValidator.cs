using FluentValidation;

namespace BlogSystem.Application.Posts.UpdatePost;

internal sealed class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(f => f.Title)
        .NotEmpty()
        .WithMessage("Title can not be empty")
        .MaximumLength(100)
        .WithMessage("Title characters can not be more than 100");

        RuleFor(f => f.Content)
        .NotEmpty()
        .WithMessage("Content can not be empty")
        .MaximumLength(5000)
        .WithMessage("Content characters can not be more than 5000");

        RuleFor(f => f.Summary)
        .NotEmpty()
        .WithMessage("Summary can not be empty")
        .MaximumLength(200)
        .WithMessage("Summary characters can not be more than 200");

        RuleFor(f => f.Author)
        .NotEmpty()
        .WithMessage("Author can not be empty")
        .MaximumLength(100)
        .WithMessage("Author characters can not be more than 100");

        RuleFor(f => f.TagNames)
        .Must(m => m.Count <= 10)
        .WithMessage("Tags can not be more than 10 items");
    }
}