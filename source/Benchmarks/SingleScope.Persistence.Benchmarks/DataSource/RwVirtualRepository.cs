using System.Linq.Expressions;

namespace SingleScope.Persistence.Benchmarks.DataSource
{
    public class RwVirtualRepository : IReadWriteRepository
    {
        public virtual EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            return default!;
        }

        public virtual Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class
        {
            return default!;
        }

        public virtual void AddRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public virtual void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }

        public virtual Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
        {
            return Task.CompletedTask;
        }

        public virtual Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.CompletedTask;
        }

        public virtual EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            return default;
        }

        public virtual void AttachRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public virtual void AttachRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }

        public virtual TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return default;
        }

        public virtual Task<TEntity?> FindAsync<TEntity>(object? keyValue, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public virtual Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public virtual TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return default;
        }

        public virtual TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
        {
            return default;
        }

        public virtual TEntity[] GetAll<TEntity>() where TEntity : class
        {
            return [];
        }

        public virtual TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return [];
        }

        public virtual Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(Array.Empty<TEntity>());
        }

        public virtual Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(Array.Empty<TEntity>());
        }

        public virtual Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public virtual Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return default!;
        }

        public virtual void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public virtual void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }

        public virtual void SaveChanges()
        {
        }

        public virtual Task SaveChangesAsync(CancellationToken cancellation = default)
        {
            return Task.CompletedTask;
        }

        public IQueryable<TEntity> TrackedQuery<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            return default;
        }

        public virtual void UpdateRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public virtual void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }
    }
}
