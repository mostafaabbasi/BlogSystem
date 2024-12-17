using BlogSystem.Domain.Abstractions;
using BlogSystem.Domain.Tags;

namespace BlogSystem.Domain.Posts;

public sealed class Post : Entity
{
    private Post(){}

    private Post(Guid id, Title title, Content content, Summary summary, Author author) : base(id)
    {
        Title = title;
        Content = content;
        Summary = summary;
        Author = author;
        CreatedAt = DateTime.UtcNow;
    }

    public static Post Create(Title title, Content content, Summary summary, Author author)
    {
        return new Post(Guid.NewGuid(), title, content, summary, author);
    }

    public void AddTag(Tag tag)
    {
        _tags.Add(tag);
    }

    private readonly List<Tag> _tags = new();

    public Title Title { get; private set; }
    public Content Content { get; private set; }
    public Summary Summary { get; private set; }
    public Author Author { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();
}