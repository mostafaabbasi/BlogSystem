using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Domain.Posts;

public sealed partial class Post : Entity
{
    private Post() { }

    private Post(Guid id, Title title, Content content, Summary summary, Author author) : base(id)
    {
        Title = title;
        Content = content;
        Summary = summary;
        Author = author;
        CreatedAt = DateTime.UtcNow;
    }

    private readonly List<PostTag> _postTags = new();

    public Title Title { get; private set; }
    public Content Content { get; private set; }
    public Summary Summary { get; private set; }
    public Author Author { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<PostTag> PostTags => _postTags.AsReadOnly();
}