using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Domain.Tags;

public sealed record TagId(Guid Value) : ValueObject<TagId>
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static implicit operator TagId(Guid value) => new(value);
}