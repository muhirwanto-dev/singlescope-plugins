namespace SingleScope.Repository.Interface
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();
    }

    public interface IReadOnlyRepository
    {
        IList<TEntity> GetAll<TEntity>() where TEntity : class;

        Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
    }
}
