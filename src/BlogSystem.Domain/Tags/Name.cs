using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Domain.Tags;

public sealed record Name : ValueObject<Name>
{
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Tag name cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public string Value { get; }

    public static implicit operator Name(string value) => new Name(value);
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}