using System.Linq.Expressions;
using SingleScope.Persistence.Entities;
using SingleScope.Persistence.Specification;

namespace SingleScope.Persistence.Repository
{
    /// <summary>
    /// Interface defining read operations for a repository.
    /// Designed to be potentially used independently (e.g., in CQRS read models).
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IReadRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity? Find<TKey>(TKey key)
            where TKey : IEquatable<TKey>;

        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity? FirstOrDefault(ISpecification<TEntity> specification);

        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity? SingleOrDefault(ISpecification<TEntity> specification);

        IList<TEntity> GetAll();

        IList<TEntity> GetAll(ISpecification<TEntity> specification);

        IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> Where(ISpecification<TEntity> specification);

        bool IsExists(Expression<Func<TEntity, bool>> predicate);

        long Count();

        long Count(Expression<Func<TEntity, bool>> predicate);

        void DetatchFromTracking(TEntity entity);

        ValueTask<TEntity?> FindAsync<TKey>(TKey key, CancellationToken cancellation = default)
            where TKey : IEquatable<TKey>;

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellation = default);

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellation = default);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellation = default);

        IAsyncEnumerable<TEntity> StreamAllAsync();

        Task<List<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellation = default);

        IAsyncEnumerable<TEntity> StreamAllAsync(ISpecification<TEntity> specification);

        Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<List<TEntity>> WhereAsync(ISpecification<TEntity> specification, CancellationToken cancellation = default);

        IAsyncEnumerable<TEntity> StreamWhereAsync(Expression<Func<TEntity, bool>> predicate);

        IAsyncEnumerable<TEntity> StreamWhereAsync(ISpecification<TEntity> specification);

        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<long> CountAsync(CancellationToken cancellation = default);

        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);
    }

    public interface IReadRepository<TEntity, TContext> : IReadRepository<TEntity>
        where TEntity : class, IEntity;
}
