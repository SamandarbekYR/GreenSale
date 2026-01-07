namespace GreenSale.Data.Entities;

public class Entity<T> : IEntity<T>, 
             IDeletable where T : IEquatable<T>
{
    public T Id { get; set; } = default!;
    public bool IsDeleted { get; set; }
}

public class Entity : Entity<Guid>
{ }