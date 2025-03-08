using System.Linq.Expressions;

namespace SingleScope.Persistence.Repository
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        TEntity[] GetAll();

        Task<TEntity[]> GetAllAsync(CancellationToken cancellation = default);

        TEntity? Get(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default);

        TEntity[] GetAll(string[] includedProperties);

        Task<TEntity[]> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default);

        TEntity? Find(params object?[]? keyValues);

        Task<TEntity?> FindAsync(object? keyValue, CancellationToken cancellation = default);

        Task<TEntity?> FindAsync(object?[]? keyValues, CancellationToken cancellation = default);
    }

    public interface IReadOnlyRepository
    {
        TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default) where TEntity : class;

        TEntity[] GetAll<TEntity>() where TEntity : class;

        Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class;

        TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class;

        TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class;

        Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class;

        TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class;

        Task<TEntity?> FindAsync<TEntity>(object? keyValue, CancellationToken cancellation = default) where TEntity : class;

        Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation = default) where TEntity : class;
    }
}
