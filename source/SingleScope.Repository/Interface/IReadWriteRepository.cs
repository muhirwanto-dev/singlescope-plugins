using System.Linq.Expressions;

namespace SingleScope.Repository.Interface
{
    public interface IReadWriteRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);

        Task CreateAsync(TEntity entity);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Patch(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames);

        Task PatchAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames);

        void PatchNotNull(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        Task PatchNotNullAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }

    public interface IReadWriteRepository : IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity) where TEntity : class;

        Task CreateAsync<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

        void Patch<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames) where TEntity : class;

        Task PatchAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate, string[] propertyNames) where TEntity : class;

        void PatchNotNull<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task PatchNotNullAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
