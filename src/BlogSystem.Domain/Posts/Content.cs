namespace BlogSystem.Domain.Posts;

public sealed record Content
{
    public Content(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Content cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public string Value { get; }

    public static implicit operator Content(string value) => new Content(value);
}