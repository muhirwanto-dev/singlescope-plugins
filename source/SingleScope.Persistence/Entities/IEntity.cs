namespace SingleScope.Persistence.Entities
{
    public interface IEntity;

    public interface IEntity<TKey> : IEntity
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
