namespace SingleScope.Repository.Interface
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();

        IList<TEntity> GetAll(string[] includedProperties);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellation = default);

        Task<List<TEntity>> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default);

        TEntity? Get(params object?[] keys);

        Task<TEntity?> GetAsync(params object?[] keys);

        Task<TEntity?> GetAsync(object?[] keys, CancellationToken cancellation = default);

        TEntity? Get(object?[] keys, string[] includedProperties, string[]? includedCollections = null);

        Task<TEntity?> GetAsync(object?[] keys, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default);
    }

    public interface IReadOnlyRepository
    {
        IList<TEntity> GetAll<TEntity>() where TEntity : class;

        IList<TEntity> GetAll<TEntity>(string[] includedProperties) where TEntity : class;

        Task<List<TEntity>> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class;

        Task<List<TEntity>> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class;

        TEntity? Get<TEntity>(params object?[] keys) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(params object?[] keys) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(object?[] keys, CancellationToken cancellation = default) where TEntity : class;

        TEntity? Get<TEntity>(object?[] keys, string[] includedProperties, string[]? includedCollections = null) where TEntity : class;

        Task<TEntity?> GetAsync<TEntity>(object?[] keys, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class;
    }
}
