using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SingleScope.Persistence.Repositories
{
    public abstract class ReadWriteRepository<TContext, TEntity> : ReadOnlyRepository<TContext, TEntity>, IReadWriteRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        public ReadWriteRepository(TContext context) : base(context)
        {
        }

        public virtual EntityEntry<TEntity> Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public virtual Task<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellation = default)
        {
            return _context.Set<TEntity>().AddAsync(entity, cancellation).AsTask();
        }

        public virtual void AddRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual Task AddRangeAsync(params TEntity[] entities)
        {
            return _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
        {
            return _context.Set<TEntity>().AddRangeAsync(entities, cancellation);
        }

        public virtual EntityEntry<TEntity> Attach(TEntity entity)
        {
            return _context.Set<TEntity>().Attach(entity);
        }

        public virtual void AttachRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public virtual void AttachRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public virtual EntityEntry<TEntity> Remove(TEntity entity)
        {
            return _context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync(CancellationToken cancellation)
        {
            return _context.SaveChangesAsync(cancellation);
        }

        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(params TEntity[] entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
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

        public virtual EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public virtual Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AddAsync(entity, cancellation).AsTask();
        }

        public virtual void AddRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
        {
            return _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AddRangeAsync(entities, cancellation);
        }

        public virtual EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Attach(entity);
        }

        public virtual void AttachRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public virtual void AttachRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().AttachRange(entities);
        }

        public virtual EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync(CancellationToken cancellation)
        {
            return _context.SaveChangesAsync(cancellation);
        }

        public virtual EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            return _context.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange<TEntity>(params TEntity[] entities) where TEntity : class
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public virtual void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
