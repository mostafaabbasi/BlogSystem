using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using FluentAssertions;

namespace BlogSystem.Domain.UnitTests.Abstractions;

public class ValueObjectsTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ValueObjects_WithEmptyValue_ShouldThrowArgumentException(string emptyValue)
    {
        // Act & Assert
        Action createTitle = () => new Title(emptyValue);
        Action createContent = () => new Content(emptyValue);
        Action createSummary = () => new Summary(emptyValue);
        Action createAuthor = () => new Author(emptyValue);
        Action createName = () => new Name(emptyValue);

        createTitle.Should()
            .Throw<ArgumentException>()
            .WithMessage("Title cannot be empty. (Parameter 'value')");

        createContent.Should()
            .Throw<ArgumentException>()
            .WithMessage("Content cannot be empty. (Parameter 'value')");

        createSummary.Should()
            .Throw<ArgumentException>()
            .WithMessage("Summary cannot be empty. (Parameter 'value')");

        createAuthor.Should()
            .Throw<ArgumentException>()
            .WithMessage("Author cannot be empty. (Parameter 'value')");
        
        createName.Should()
            .Throw<ArgumentException>()
            .WithMessage("Tag name cannot be empty. (Parameter 'value')");
    }

    [Theory]
    [InlineData("Valid Value")]
    [InlineData("A")]
    [InlineData("Valid Value With Multiple Words")]
    public void ValueObjects_WithValidValue_ShouldCreateInstance(string validValue)
    {
        // Act
        var title = new Title(validValue);
        var content = new Content(validValue);
        var summary = new Summary(validValue);
        var author = new Author(validValue);

        // Assert
        title.Value.Should().Be(validValue);
        content.Value.Should().Be(validValue);
        summary.Value.Should().Be(validValue);
        author.Value.Should().Be(validValue);
    }
}