using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Domain.Posts;

public sealed record PostId(Guid Value) : ValueObject<PostId>
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static implicit operator PostId(Guid value) => new(value);
}