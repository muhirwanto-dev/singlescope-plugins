namespace SingleScope.Persistence.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity? Get(Func<TEntity, bool> predicate);

        Task<TEntity?> GetAsync(Func<TEntity, bool> predicate, CancellationToken cancellation = default);

        TEntity[] GetAll();

        Task<TEntity[]> GetAllAsync(CancellationToken cancellation = default);

        TEntity? Get(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null);

        Task<TEntity?> GetAsync(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default);

        TEntity[] GetAll(string[] includedProperties);

        Task<TEntity[]> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default);

        TEntity? Find(params object?[]? keyValues);

        Task<TEntity?> FindAsync(params object?[]? keyValues);

        Task<TEntity?> FindAsync(object?[]? keyValues, CancellationToken cancellation);
    }

    public interface IReadOnlyRepository
    {
        TEntity? Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(Func<TEntity, bool> predicate, CancellationToken cancellation = default) where TEntity : class;

        TEntity[] GetAll<TEntity>() where TEntity : class;

        Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class;

        TEntity? Get<TEntity>(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class;

        TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class;

        Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class;

        TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class;

        Task<TEntity?> FindAsync<TEntity>(params object?[]? keyValues) where TEntity : class;

        Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation) where TEntity : class;
    }
}
