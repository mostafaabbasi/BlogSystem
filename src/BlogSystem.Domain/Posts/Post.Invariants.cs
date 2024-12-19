using BlogSystem.Domain.Tags;

namespace BlogSystem.Domain.Posts;

public sealed partial class Post
{
    private const int MaxTags = 10;
    
    public static Post Create(
        string title,
        string content,
        string summary,
        string author,
        List<Tag> tags)
    {
        var post = new Post(Guid.NewGuid(),
        new Title(title),
        new Content(content),
        new Summary(summary),
        new Author(author));

        post.AddTags(tags);

        return post;
    }

    public void Update(
        string title,
        string content,
        string summary,
        string author,
        List<Tag> tags)
    {
        Title = title;
        Content = content;
        Summary = summary;
        Author = author;
        _tags.Clear();
        AddTags(tags);
    }

    private void AddTags(List<Tag> tags)
    {
        if (_tags.Count >= MaxTags)
            throw new InvalidOperationException($"A post cannot have more than {MaxTags} tags.");

        _tags.AddRange(tags);
    }
}