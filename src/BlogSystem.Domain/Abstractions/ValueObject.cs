namespace BlogSystem.Domain.Abstractions;

public abstract record ValueObject<T> where T : ValueObject<T>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public virtual bool Equals(ValueObject<T>? other) 
        => other is not null &&
           other is T valueObject &&
           other.GetType() == GetType() &&
           GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());

    public override int GetHashCode()
        => GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
}