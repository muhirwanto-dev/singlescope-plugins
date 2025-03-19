using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SingleScope.Persistence.Repository;

namespace SingleScope.Persistence.Benchmarks.DataSource
{
    public class RwNonVirtualRepository : IReadWriteRepository
    {
        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            return default!;
        }

        public Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class
        {
            return default!;
        }

        public void AddRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }

        public Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
        {
            return Task.CompletedTask;
        }

        public Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.CompletedTask;
        }

        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            return default;
        }

        public void AttachRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public void AttachRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }

        public TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return default;
        }

        public Task<TEntity?> FindAsync<TEntity>(object? keyValue, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return default;
        }

        public TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
        {
            return default;
        }

        public TEntity[] GetAll<TEntity>() where TEntity : class
        {
            return [];
        }

        public TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return [];
        }

        public Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(Array.Empty<TEntity>());
        }

        public Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(Array.Empty<TEntity>());
        }

        public Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class
        {
            return Task.FromResult(default(TEntity));
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return default;
        }

        public void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }

        public void SaveChanges()
        {
        }

        public Task SaveChangesAsync(CancellationToken cancellation = default)
        {
            return Task.CompletedTask;
        }

        public IQueryable<TEntity> TrackedQuery<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            return default!;
        }

        public void UpdateRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
        }

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
        }
    }
}
