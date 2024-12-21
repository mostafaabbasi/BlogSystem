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
        List<TagId> tagIds)
    {
        var post = new Post(Guid.NewGuid(),
            new Title(title),
            new Content(content),
            new Summary(summary),
            new Author(author));

        post.AddTags(tagIds);

        return post;
    }

    public void Update(
        string title,
        string content,
        string summary,
        string author,
        List<TagId> tagIds)
    {
        Title = title;
        Content = content;
        Summary = summary;
        Author = author;
        _tagIds.Clear();
        AddTags(tagIds);
    }

    private void AddTags(List<TagId> tagIds)
    {
        foreach (var tagId in tagIds)
        {
            if (_tagIds.Count >= MaxTags)
                throw new InvalidOperationException($"A post cannot have more than {MaxTags} tags.");
            
            _tagIds.Add(tagId);
        }
    }
}