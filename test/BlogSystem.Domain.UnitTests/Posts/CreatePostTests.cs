using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using FluentAssertions;

namespace BlogSystem.Domain.UnitTests.Posts;

public class CreatePostTests
{
    private readonly string _validTitle = "Valid Title";
    private readonly string _validContent = "Valid Content";
    private readonly string _validSummary = "Valid Summary";
    private readonly string _validAuthor = "Valid Author";
    private readonly List<TagId> _validTags;

    public CreatePostTests()
    {
        _validTags = new List<TagId> { new TagId(Guid.NewGuid()) };
    }

    [Fact]
    public void Create_WithValidInputs_ShouldCreatePost()
    {
        // Act
        var post = Post.Create(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            _validTags);

        // Assert
        post.Should().NotBeNull();
        post.Title.Value.Should().Be(_validTitle);
        post.Content.Value.Should().Be(_validContent);
        post.Summary.Value.Should().Be(_validSummary);
        post.Author.Value.Should().Be(_validAuthor);
        post.TagIds.Should().BeEquivalentTo(_validTags);
    }

    [Fact]
    public void Create_WithEmptyTagList_ShouldCreatePost()
    {
        // Arrange
        var emptyTags = new List<TagId>();

        // Act
        var post = Post.Create(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            emptyTags);

        // Assert
        post.Should().NotBeNull();
        post.TagIds.Should().BeEmpty();
    }

    [Fact]
    public void Create_WithMaxTags_ShouldCreatePost()
    {
        // Arrange
        var maxTags = new List<TagId>();
        for (int i = 0; i < 10; i++)
        {
            maxTags.Add(new TagId(Guid.NewGuid()));
        }

        // Act
        var post = Post.Create(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            maxTags);

        // Assert
        post.TagIds.Should().HaveCount(10);
        post.TagIds.Should().BeEquivalentTo(maxTags);
    }

    [Fact]
    public void Create_WithMoreThanMaxTags_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var tooManyTags = new List<TagId>();
        for (int i = 0; i < 11; i++)
        {
            tooManyTags.Add(new TagId(Guid.NewGuid()));
        }

        // Act & Assert
        var action = () => Post.Create(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            tooManyTags);

        action.Should().Throw<InvalidOperationException>()
            .WithMessage("A post cannot have more than 10 tags.");
    }
}
