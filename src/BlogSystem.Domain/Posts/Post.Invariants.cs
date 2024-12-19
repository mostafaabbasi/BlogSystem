namespace BlogSystem.Domain.Posts;

public sealed partial class Post
{
    private const int MaxTags = 10;
    
    public static Post Create(
        string title,
        string content,
        string summary,
        string author,
        List<Guid> tagIds)
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
        List<Guid> tagIds)
    {
        Title = title;
        Content = content;
        Summary = summary;
        Author = author;
        _postTags.Clear();
        AddTags(tagIds);
    }

    private void AddTags(List<Guid> tagIds)
    {
        if (_postTags.Count >= MaxTags)
            throw new InvalidOperationException($"A post cannot have more than {MaxTags} tags.");

        foreach (var tagId in tagIds)
        {
            var postTag = new PostTag()
            {
                PostId = Id,
                TagId = tagId
            };
            _postTags.Add(postTag);
        }
    }
}