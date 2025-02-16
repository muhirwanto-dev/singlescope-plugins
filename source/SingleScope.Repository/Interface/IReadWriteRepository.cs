using System.Linq.Expressions;

namespace SingleScope.Repository.Interface
{
    public interface IReadWriteRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);

        Task CreateAsync(TEntity entity, CancellationToken cancellation = default);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity, CancellationToken cancellation = default);

        void Patch(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames);

        Task PatchAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames, CancellationToken cancellation = default);

        void PatchNotNull(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        Task PatchNotNullAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity, CancellationToken cancellation = default);
    }

    public interface IReadWriteRepository : IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity) where TEntity : class;

        Task CreateAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class;

        void Patch<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames) where TEntity : class;

        Task PatchAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames, CancellationToken cancellation = default) where TEntity : class;

        void PatchNotNull<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task PatchNotNullAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        Task DeleteAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class;
    }
}
