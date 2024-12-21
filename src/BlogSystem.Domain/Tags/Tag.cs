using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Domain.Tags;

public sealed class Tag : Entity<TagId>
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
    
    public Name Name { get; private set; }    
}