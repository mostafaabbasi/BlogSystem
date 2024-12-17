namespace BlogSystem.Domain.Posts;

public sealed class PostTag
{
    public Guid PostId { get; set; }
    public Guid TagId { get; set; }
}