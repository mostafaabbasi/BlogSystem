using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using FluentAssertions;

namespace BlogSystem.Domain.UnitTests.Posts;


public class UpdatePostTests
{
    private readonly string _validTitle = "Valid Title";
    private readonly string _validContent = "Valid Content";
    private readonly string _validSummary = "Valid Summary";
    private readonly string _validAuthor = "Valid Author";
    private readonly List<TagId> _validTags;
    private readonly Post _existingPost;

    public UpdatePostTests()
    {
        _validTags = new List<TagId> { new TagId(Guid.NewGuid()) };
        _existingPost = Post.Create(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            _validTags);
    }

    [Fact]
    public void Update_WithValidInputs_ShouldUpdatePost()
    {
        // Arrange
        var newTitle = "New Title";
        var newContent = "New Content";
        var newSummary = "New Summary";
        var newAuthor = "New Author";
        var newTags = new List<TagId> { new TagId(Guid.NewGuid()) };

        // Act
        _existingPost.Update(newTitle, newContent, newSummary, newAuthor, newTags);

        // Assert
        _existingPost.Title.Value.Should().Be(newTitle);
        _existingPost.Content.Value.Should().Be(newContent);
        _existingPost.Summary.Value.Should().Be(newSummary);
        _existingPost.Author.Value.Should().Be(newAuthor);
        _existingPost.TagIds.Should().BeEquivalentTo(newTags);
    }

    [Fact]
    public void Update_WithEmptyTagList_ShouldClearAllTags()
    {
        // Arrange
        var emptyTags = new List<TagId>();

        // Act
        _existingPost.Update(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            emptyTags);

        // Assert
        _existingPost.TagIds.Should().BeEmpty();
    }

    [Fact]
    public void Update_WithMaxTags_ShouldUpdateTags()
    {
        // Arrange
        var maxTags = new List<TagId>();
        for (int i = 0; i < 10; i++)
        {
            maxTags.Add(new TagId(Guid.NewGuid()));
        }

        // Act
        _existingPost.Update(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            maxTags);

        // Assert
        _existingPost.TagIds.Should().HaveCount(10);
        _existingPost.TagIds.Should().BeEquivalentTo(maxTags);
    }

    [Fact]
    public void Update_WithMoreThanMaxTags_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var tooManyTags = new List<TagId>();
        for (int i = 0; i < 11; i++)
        {
            tooManyTags.Add(new TagId(Guid.NewGuid()));
        }

        // Act & Assert
        var action = () => _existingPost.Update(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            tooManyTags);

        action.Should().Throw<InvalidOperationException>()
            .WithMessage("A post cannot have more than 10 tags.");
    }

    [Fact]
    public void Update_ShouldClearExistingTagsBeforeAddingNewOnes()
    {
        // Arrange
        var newTags = new List<TagId> { new TagId(Guid.NewGuid()) };

        // Act
        _existingPost.Update(
            _validTitle,
            _validContent,
            _validSummary,
            _validAuthor,
            newTags);

        // Assert
        _existingPost.TagIds.Should().HaveCount(1);
        _existingPost.TagIds.Should().BeEquivalentTo(newTags);
        _existingPost.TagIds.Should().NotContain(_validTags);
    }
}