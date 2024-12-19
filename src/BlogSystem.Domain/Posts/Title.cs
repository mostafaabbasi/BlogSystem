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

    public static implicit operator Title(string value) => new Title(value);
}