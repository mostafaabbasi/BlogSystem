using BlogSystem.Domain.Abstractions;

namespace BlogSystem.Domain.Posts;

public sealed record Author : ValueObject<Author>
{
    public Author(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Author cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public string Value { get; }

    public static implicit operator Author(string value) => new Author(value);
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}