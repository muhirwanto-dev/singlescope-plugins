using SingleScope.Persistence.Entities;

namespace SingleScope.Persistence.Repository
{
    /// <summary>
    /// Combines read and write repository operations.
    /// This is the most commonly used repository interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IReadWriteRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
        where TEntity : class, IEntity
    {
    }

    public interface IReadWriteRepository<TEntity, TContext> : IReadWriteRepository<TEntity>
        where TEntity : class, IEntity;
}
