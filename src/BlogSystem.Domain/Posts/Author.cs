namespace BlogSystem.Domain.Posts;

public sealed record Author
{
    public Author(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Author cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public string Value { get; }
}