namespace BlogSystem.Domain.Posts;

public sealed record Title
{
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Title cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public string Value { get; }
}