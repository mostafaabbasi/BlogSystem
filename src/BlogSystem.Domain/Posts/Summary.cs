using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Domain.Posts;

public sealed record Summary : ValueObject<Summary>
{
    public Summary(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Summary cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public string Value { get; }

    public static implicit operator Summary(string value) => new Summary(value);
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}