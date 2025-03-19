using System.Linq.Expressions;

namespace SingleScope.Persistence.Repository
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);

        TEntity? Get(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null);

        TEntity[] GetAll();

        TEntity[] GetAll(string[] includedProperties);

        TEntity? Find(params object?[]? keyValues);

        IQueryable<TEntity> Query();

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default);

        Task<TEntity[]> GetAllAsync(CancellationToken cancellation = default);

        Task<TEntity[]> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default);

        Task<TEntity?> FindAsync(object? keyValue, CancellationToken cancellation = default);

        Task<TEntity?> FindAsync(object?[]? keyValues, CancellationToken cancellation = default);
    }

    public interface IReadOnlyRepository
    {
        TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class;

        TEntity[] GetAll<TEntity>() where TEntity : class;

        TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class;

        TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class;

        IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class;

        Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class;

        Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class;

        Task<TEntity?> FindAsync<TEntity>(object? keyValue, CancellationToken cancellation = default) where TEntity : class;

        Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation = default) where TEntity : class;
    }
}
