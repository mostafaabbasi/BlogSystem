using BlogSystem.Domain.Tags;

namespace BlogSystem.Domain.Posts;

public sealed class PostTag
{
    public Guid PostId { get; init; }
    public Guid TagId { get; init; }
    public Post Post { get; set; }
    public Tag Tag { get; set; }
}