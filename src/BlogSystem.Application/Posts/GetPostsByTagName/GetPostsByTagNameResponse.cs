namespace BlogSystem.Application.Posts.GetPostsByTagName;

public sealed class GetPostsByTagNameResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public string Summary { get; init; }
    public string Author { get; init; }
    public DateTime CreatedAt { get; init; }
    public List<string> TagNames { get; set; }
}