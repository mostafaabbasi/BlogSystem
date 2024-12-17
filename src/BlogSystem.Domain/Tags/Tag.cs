using BlogSystem.Domain.Abstractions;
using BlogSystem.Domain.Posts;

namespace BlogSystem.Domain.Tags;

public sealed class Tag : Entity
{
#pragma warning disable CS8618
    private Tag()
    {
        
    }
#pragma warning restore CS8618
    private Tag(Guid id, Name name) : base(id)
    {
        Id = id;
        Name = name;
    }

    public static Tag Create(Name name)
    {
        return new Tag(Guid.NewGuid(), name);
    }
    
    private readonly List<Post> _posts = new();
    private readonly List<PostTag> _postTags = new();
    
    public Guid Id { get; private set; }
    public Name Name { get; private set; }
    
    public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
    public IReadOnlyCollection<PostTag> PostTags => _postTags.AsReadOnly();
}