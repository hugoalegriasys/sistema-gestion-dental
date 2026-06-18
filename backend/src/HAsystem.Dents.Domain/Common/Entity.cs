namespace HAsystem.Dents.Domain.Common;

public abstract class Entity<TId>
{
    int? _requestedHashCode;
    public virtual TId Id { get; protected set; } = default!;

    public bool IsTransient()
    {
        return EqualityComparer<TId>.Default.Equals(Id, default);
    }
    public override int GetHashCode()
    {
        if (IsTransient())
            return base.GetHashCode();

        _requestedHashCode ??= Id.GetHashCode() ^ 31; // XOR for random distribution
        return _requestedHashCode.Value;
    }
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        if (Equals(left, null))
            return Equals(right, null);
        else
            return left.Equals(right);
    }
    public static bool operator !=(Entity<TId> left, Entity<TId> right) => !(left == right);
    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> item)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        return !IsTransient() && !item.IsTransient() && EqualityComparer<TId>.Default.Equals(Id, item.Id);
    }
}