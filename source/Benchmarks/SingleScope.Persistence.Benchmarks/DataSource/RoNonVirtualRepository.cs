using System.Linq.Expressions;
using SingleScope.Persistence.Repository;

namespace SingleScope.Persistence.Benchmark.DataSource
{
    public class RoNonVirtualRepository : IReadOnlyRepository
    {
        public TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return null;
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
            return null;
        }

        public TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
        {
            return null;
        }

        public TEntity[] GetAll<TEntity>() where TEntity : class
        {
            return Array.Empty<TEntity>();
        }

        public TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return Array.Empty<TEntity>();
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
    }
}
