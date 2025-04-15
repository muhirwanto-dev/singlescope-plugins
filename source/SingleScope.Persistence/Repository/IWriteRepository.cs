using SingleScope.Persistence.Entities;

namespace SingleScope.Persistence.Repository
{
    /// <summary>
    /// Interface defining write operations for a repository.
    /// Designed to be potentially used independently.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
    public interface IWriteRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        void Add(TEntity entity);

        /// <summary>
        /// Adds multiple entities.
        /// </summary>
        /// <param name="entities">The collection of entities to add.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <remarks>
        /// Implementation details vary (e.g., EF Core tracks changes, Dapper requires explicit UPDATE SQL).
        /// </remarks>
        /// <returns>Task representing the asynchronous operation.</returns>
        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes an entity by its primary key.
        /// </summary>
        /// <param name="id">The primary key of the entity to delete.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        void Delete(TKey id);

        void DeleteRange(IEnumerable<TKey> ids);

        ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);

        Task DeleteRangeAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);
    }
}
