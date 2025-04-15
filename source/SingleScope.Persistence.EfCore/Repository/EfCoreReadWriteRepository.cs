using Microsoft.EntityFrameworkCore;
using SingleScope.Persistence.EFCore.Repository;
using SingleScope.Persistence.Entities;
using SingleScope.Persistence.Querying;
using SingleScope.Persistence.Repository;

namespace SingleScope.Persistence.EfCore.Repository
{
    /// <summary>
    /// Generic repository implementation using Entity Framework Core.
    /// This class is designed to be inheritable by specific repositories in consuming applications.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TKey">The entity's primary key type.</typeparam>
    /// <typeparam name="TContext">The DbContext type.</typeparam>
    public class EfCoreReadWriteRepository<TEntity, TKey, TContext> : EfCoreReadOnlyRepository<TEntity, TKey, TContext>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TContext : DbContext
    {
        public EfCoreReadWriteRepository(TContext dbContext, ISpecificationEvaluator specificationEvaluator)
            : base(dbContext, specificationEvaluator)
        {
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public async ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _set.AddAsync(entity, cancellationToken);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _set.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return _set.AddRangeAsync(entities, cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public void Delete(TKey id)
        {
            var entity = _set.Find(id);
            if (entity != null)
            {
                _set.Remove(entity);
            }
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _set.Remove(entity);

            return Task.CompletedTask;
        }

        public async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _set.FindAsync(id, cancellationToken);
            if (entity != null)
            {
                _set.Remove(entity);
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _set.RemoveRange(entities);
        }

        public void DeleteRange(IEnumerable<TKey> ids)
        {
            var entities = base.Where(e => ids.Contains(e.Id));
            if (entities.Any())
            {
                _set.RemoveRange(entities);
            }
        }

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            this.DeleteRange(entities);

            return Task.CompletedTask;
        }

        public async Task DeleteRangeAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default)
        {
            var entities = await base.WhereAsync(e => ids.Contains(e.Id), cancellationToken);
            if (entities.Any())
            {
                _set.RemoveRange(entities);
            }
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.Update(entity);

            return Task.CompletedTask;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _set.UpdateRange(entities);
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            this.UpdateRange(entities);

            return Task.CompletedTask;
        }
    }
}
