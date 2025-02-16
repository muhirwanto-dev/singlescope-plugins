using Microsoft.EntityFrameworkCore;
using SingleScope.Repository.Interface;

namespace SingleScope.Repository
{
    public abstract class ReadOnlyRepository<TContext, TEntity> : ReadOnlyRepository<TContext>, IReadOnlyRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public ReadOnlyRepository(TContext context) : base(context)
        {
        }

        public virtual IList<TEntity> GetAll()
        {
            return base.GetAll<TEntity>();
        }

        public virtual IList<TEntity> GetAll(string[] includedProperties)
        {
            return base.GetAll<TEntity>(includedProperties);
        }

        public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellation = default)
        {
            return base.GetAllAsync<TEntity>(cancellation);
        }

        public virtual Task<List<TEntity>> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default)
        {
            return base.GetAllAsync<TEntity>(includedProperties, cancellation);
        }

        public virtual TEntity? Get(params object?[] keys)
        {
            return base.Get<TEntity>(keys);
        }

        public virtual Task<TEntity?> GetAsync(params object?[] keys)
        {
            return base.GetAsync<TEntity>(keys);
        }

        public virtual Task<TEntity?> GetAsync(object?[] keys, CancellationToken cancellation = default)
        {
            return base.GetAsync<TEntity>(keys, cancellation);
        }

        public virtual TEntity? Get(object?[] keys, string[] includedProperties, string[]? includedCollections = null)
        {
            return base.Get<TEntity>(keys, includedProperties, includedCollections);
        }

        public virtual Task<TEntity?> GetAsync(object?[] keys, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default)
        {
            return base.GetAsync<TEntity>(keys, includedProperties, includedCollections, cancellation);
        }
    }

    public abstract class ReadOnlyRepository<TContext> : RepositoryBase<TContext>, IReadOnlyRepository
        where TContext : DbContext
    {
        public ReadOnlyRepository(TContext context) : base(context)
        {
        }

        public virtual IList<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .ToList();
        }

        public virtual IList<TEntity> GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .Include(string.Join(".", includedProperties))
                .ToList();
        }

        public virtual Task<List<TEntity>> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync(cancellation);
        }

        public virtual Task<List<TEntity>> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .Include(string.Join(".", includedProperties))
                .ToListAsync(cancellation);
        }

        public virtual TEntity? Get<TEntity>(params object?[] keys) where TEntity : class
        {
            return _context.Find<TEntity>(keys);
        }

        public virtual Task<TEntity?> GetAsync<TEntity>(params object?[] keys) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keys).AsTask();
        }

        public virtual Task<TEntity?> GetAsync<TEntity>(object?[] keys, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keys, cancellation).AsTask();
        }

        public virtual TEntity? Get<TEntity>(object?[] keys, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
        {
            var entity = Get<TEntity>(keys);
            if (entity != null)
            {
                foreach (var property in includedProperties)
                {
                    _context.Entry(entity)
                        .Reference(property)
                        .Load();
                }

                foreach (var collection in includedCollections ?? [])
                {
                    _context.Entry(entity)
                        .Collection(collection)
                        .Load();
                }
            }

            return entity;
        }

        public virtual async Task<TEntity?> GetAsync<TEntity>(object?[] keys, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class
        {
            var entity = await GetAsync<TEntity>(keys, cancellation);
            if (entity != null)
            {
                foreach (var property in includedProperties)
                {
                    await _context.Entry(entity)
                        .Reference(property)
                        .LoadAsync(cancellation);
                }

                foreach (var collection in includedCollections ?? [])
                {
                    await _context.Entry(entity)
                        .Collection(collection)
                        .LoadAsync(cancellation);
                }
            }

            return entity;
        }
    }
}
