namespace BlogSystem.Domain.Abstractions;

public abstract class Entity<TIdType> where TIdType : notnull
{
    protected Entity(){}
    
    protected Entity(TIdType id)
    {
        Id = id;
    }

    public TIdType Id { get; init; }

    public override bool Equals(object? obj)
        => obj is not null &&
           obj is Entity<TIdType> entity &&
           obj.GetType() == GetType() &&
           Id.Equals(entity.Id);

    public static bool operator ==(Entity<TIdType> left, Entity<TIdType> right)
        => left.Equals(right);

    public static bool operator !=(Entity<TIdType> left, Entity<TIdType> right)
        => !left.Equals(right);
}