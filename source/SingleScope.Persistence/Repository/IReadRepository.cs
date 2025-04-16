using System.Linq.Expressions;
using SingleScope.Persistence.Entities;
using SingleScope.Persistence.Querying;

namespace SingleScope.Persistence.Repository
{
    /// <summary>
    /// Interface defining read operations for a repository.
    /// Designed to be potentially used independently (e.g., in CQRS read models).
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
    public interface IReadRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity? Find(TKey key);

        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity? FirstOrDefault(ISpecification<TEntity> specification);

        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity? SingleOrDefault(ISpecification<TEntity> specification);

        IList<TEntity> GetAll();

        IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> Where(ISpecification<TEntity> specification);

        bool IsExists(Expression<Func<TEntity, bool>> predicate);

        long Count();

        long Count(Expression<Func<TEntity, bool>> predicate);

        ValueTask<TEntity?> FindAsync(TKey key, CancellationToken cancellation = default);

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellation = default);

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellation = default);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellation = default);

        Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<List<TEntity>> WhereAsync(ISpecification<TEntity> specification, CancellationToken cancellation = default);

        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<long> CountAsync(CancellationToken cancellation = default);

        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);
    }

    public interface IReadRepository<TEntity, TKey, TContext> : IReadRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>;
}
