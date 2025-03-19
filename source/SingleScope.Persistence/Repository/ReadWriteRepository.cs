using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SingleScope.Persistence.Repository
{
    public abstract class ReadWriteRepository<TContext, TEntity> : ReadOnlyRepository<TContext, TEntity>, IReadWriteRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        public ReadWriteRepository(TContext context) : base(context)
        {
        }

        public EntityEntry<TEntity> Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public Task<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellation = default)
        {
            return _context.Set<TEntity>().AddAsync(entity, cancellation).AsTask();
        }

        public void AddRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public Task AddRangeAsync(params TEntity[] entities)
        {
            return _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            return _context.Set<TEntity>().AddRangeAsync(entities, cancellation);
        }

        public EntityEntry<TEntity> Attach(TEntity entity)
        {
            return _context.Set<TEntity>().Attach(entity);
        }

        public void AttachRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public void AttachRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public IQueryable<TEntity> TrackedQuery()
        {
            return _context.Set<TEntity>().AsTracking();
        }

        public EntityEntry<TEntity> Remove(TEntity entity)
        {
            return _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync(CancellationToken cancellation = default)
        {
            return _context.SaveChangesAsync(cancellation);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }
    }

    public abstract class ReadWriteRepository<TContext> : ReadOnlyRepository<TContext>, IReadWriteRepository
        where TContext : DbContext
    {
        public ReadWriteRepository(TContext context) : base(context)
        {
        }

        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AddAsync(entity, cancellation).AsTask();
        }

        public void AddRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
        {
            return _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AddRangeAsync(entities, cancellation);
        }

        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Attach(entity);
        }

        public void AttachRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public void AttachRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public IQueryable<TEntity> TrackedQuery<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().AsTracking();
        }

        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync(CancellationToken cancellation = default)
        {
            return _context.SaveChangesAsync(cancellation);
        }

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
