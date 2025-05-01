using System.Linq.Expressions;

namespace SingleScope.Persistence.Benchmark.DataSource
{
    public class RoVirtualRepository : IReadOnlyRepository
    {
        public virtual TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return null;
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
            return null;
        }

        public virtual TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
        {
            return null;
        }

        public virtual TEntity[] GetAll<TEntity>() where TEntity : class
        {
            return Array.Empty<TEntity>();
        }

        public virtual TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return Array.Empty<TEntity>();
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
    }
}
