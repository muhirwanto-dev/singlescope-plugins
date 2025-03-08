using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SingleScope.Persistence.Repository
{
    public interface IReadWriteRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        EntityEntry<TEntity> Add(TEntity entity);

        EntityEntry<TEntity> Attach(TEntity entity);

        EntityEntry<TEntity> Remove(TEntity entity);

        EntityEntry<TEntity> Update(TEntity entity);

        void AddRange(params TEntity[] entities);

        void AttachRange(params TEntity[] entities);

        void RemoveRange(params TEntity[] entities);

        void UpdateRange(params TEntity[] entities);

        void AddRange(IEnumerable<TEntity> entities);

        void AttachRange(IEnumerable<TEntity> entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);

        Task<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellation = default);

        Task AddRangeAsync(params TEntity[] entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default);

        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellation = default);
    }

    public interface IReadWriteRepository : IReadOnlyRepository
    {
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;

        void AddRange<TEntity>(params TEntity[] entities) where TEntity : class;

        void AttachRange<TEntity>(params TEntity[] entities) where TEntity : class;

        void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class;

        void UpdateRange<TEntity>(params TEntity[] entities) where TEntity : class;

        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void AttachRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class;

        Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class;

        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellation = default) where TEntity : class;

        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellation = default);
    }
}
