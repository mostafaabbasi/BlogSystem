namespace BlogSystem.Domain.Tags;

public sealed record Name
{
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Tag name cannot be empty.", nameof(value));

        Value = value.Trim();
    }

    public Name(string value, Func<string, bool> isDuplicate)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Tag name cannot be empty.", nameof(value));

        if (isDuplicate(value))
            throw new InvalidOperationException($"Tag name '{value}' already exists in the database.");

        Value = value.Trim();
    }

    public string Value { get; }

    public static implicit operator Name(string value) => new Name(value);
}