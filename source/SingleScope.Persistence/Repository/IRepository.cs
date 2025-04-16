using SingleScope.Persistence.Entities;

namespace SingleScope.Persistence.Repository
{
    /// <summary>
    /// Combines read and write repository operations.
    /// This is the most commonly used repository interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
    public interface IRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }

    public interface IRepository<TEntity, TKey, TContext> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>;
}
