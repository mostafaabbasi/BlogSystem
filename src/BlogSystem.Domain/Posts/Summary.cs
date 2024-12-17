namespace BlogSystem.Domain.Posts;

public sealed record Summary
{
    public Summary(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Summary cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public string Value { get; }
}