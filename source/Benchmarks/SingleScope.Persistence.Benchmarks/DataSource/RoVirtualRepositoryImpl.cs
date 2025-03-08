using System.Linq.Expressions;

namespace SingleScope.Persistence.Benchmark.DataSource
{
    internal class RoVirtualRepositoryImpl : RoVirtualRepository
    {
        public override TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return base.Find<TEntity>(keyValues);
        }

        public override Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation = default) where TEntity : class
        {
            return base.FindAsync<TEntity>(keyValues, cancellation);
        }

        public override Task<TEntity?> FindAsync<TEntity>(object? keyValue, CancellationToken cancellation = default) where TEntity : class
        {
            return base.FindAsync<TEntity>(keyValue, cancellation);
        }

        public override TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return base.Get(predicate);
        }

        public override TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
        {
            return base.Get(predicate, includedProperties, includedCollections);
        }

        public override Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default) where TEntity : class
        {
            return base.GetAsync(predicate, cancellation);
        }

        public override Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class
        {
            return base.GetAsync(predicate, includedProperties, includedCollections, cancellation);
        }

        public override TEntity[] GetAll<TEntity>()
        {
            return base.GetAll<TEntity>();
        }

        public override TEntity[] GetAll<TEntity>(string[] includedProperties)
        {
            return base.GetAll<TEntity>(includedProperties);
        }

        public override Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default)
        {
            return base.GetAllAsync<TEntity>(cancellation);
        }

        public override Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default)
        {
            return base.GetAllAsync<TEntity>(includedProperties, cancellation);
        }
    }
}
