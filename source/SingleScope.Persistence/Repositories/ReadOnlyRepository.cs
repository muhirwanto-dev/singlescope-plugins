using Microsoft.EntityFrameworkCore;

namespace SingleScope.Persistence.Repositories
{
    public abstract class ReadOnlyRepository<TContext, TEntity> : ReadOnlyRepository<TContext>, IReadOnlyRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public ReadOnlyRepository(TContext context) : base(context)
        {
        }

        public virtual TEntity? Find(params object?[]? keyValues)
        {
            return Find<TEntity>(keyValues);
        }

        public virtual Task<TEntity?> FindAsync(params object?[]? keyValues)
        {
            return FindAsync<TEntity>(keyValues);
        }

        public virtual Task<TEntity?> FindAsync(object?[]? keyValues, CancellationToken cancellation)
        {
            return FindAsync<TEntity>(keyValues, cancellation);
        }

        public virtual TEntity? Get(Func<TEntity, bool> predicate)
        {
            return base.Get(predicate);
        }

        public virtual TEntity? Get(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null)
        {
            return base.Get(predicate, includedProperties, includedCollections);
        }

        public virtual TEntity[] GetAll()
        {
            return GetAll<TEntity>();
        }

        public virtual TEntity[] GetAll(string[] includedProperties)
        {
            return GetAll<TEntity>(includedProperties);
        }

        public virtual Task<TEntity[]> GetAllAsync(CancellationToken cancellation = default)
        {
            return GetAllAsync<TEntity>(cancellation);
        }

        public virtual Task<TEntity[]> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default)
        {
            return GetAllAsync<TEntity>(includedProperties, cancellation);
        }

        public virtual Task<TEntity?> GetAsync(Func<TEntity, bool> predicate, CancellationToken cancellation = default)
        {
            return base.GetAsync(predicate, cancellation);
        }

        public virtual Task<TEntity?> GetAsync(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default)
        {
            return base.GetAsync(predicate, includedProperties, includedCollections, cancellation);
        }
    }

    public abstract class ReadOnlyRepository<TContext> : RepositoryBase<TContext>, IReadOnlyRepository
        where TContext : DbContext
    {
        public ReadOnlyRepository(TContext context) : base(context)
        {
        }

        public virtual TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return _context.Find<TEntity>(keyValues);
        }

        public virtual Task<TEntity?> FindAsync<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keyValues).AsTask();
        }

        public virtual Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keyValues, cancellation).AsTask();
        }

        public virtual TEntity? Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().SingleOrDefault(predicate);
        }

        public virtual TEntity? Get<TEntity>(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
        {
            var entity = Get(predicate);
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

        public virtual TEntity[] GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().ToArray();
        }

        public virtual TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().Include(string.Join(".", includedProperties)).ToArray();
        }

        public virtual Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().ToArrayAsync(cancellation);
        }

        public virtual Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().Include(string.Join(".", includedProperties)).ToArrayAsync(cancellation);
        }

        public virtual Task<TEntity?> GetAsync<TEntity>(Func<TEntity, bool> predicate, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(x => predicate(x), cancellation);
        }

        public virtual async Task<TEntity?> GetAsync<TEntity>(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class
        {
            var entity = await GetAsync(predicate);
            if (entity != null)
            {
                foreach (var property in includedProperties)
                {
                    await _context.Entry(entity)
                        .Reference(property)
                        .LoadAsync();
                }

                foreach (var collection in includedCollections ?? [])
                {
                    await _context.Entry(entity)
                        .Collection(collection)
                        .LoadAsync();
                }
            }

            return entity;
        }
    }
}
