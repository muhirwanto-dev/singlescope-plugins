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

        public TEntity? Find(params object?[]? keyValues)
        {
            return Find<TEntity>(keyValues);
        }

        public Task<TEntity?> FindAsync(params object?[]? keyValues)
        {
            return FindAsync<TEntity>(keyValues);
        }

        public Task<TEntity?> FindAsync(object?[]? keyValues, CancellationToken cancellation)
        {
            return FindAsync<TEntity>(keyValues, cancellation);
        }

        public TEntity? Get(Func<TEntity, bool> predicate)
        {
            return base.Get(predicate);
        }

        public TEntity? Get(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null)
        {
            return base.Get(predicate, includedProperties, includedCollections);
        }

        public TEntity[] GetAll()
        {
            return GetAll<TEntity>();
        }

        public TEntity[] GetAll(string[] includedProperties)
        {
            return GetAll<TEntity>(includedProperties);
        }

        public Task<TEntity[]> GetAllAsync(CancellationToken cancellation = default)
        {
            return GetAllAsync<TEntity>(cancellation);
        }

        public Task<TEntity[]> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default)
        {
            return GetAllAsync<TEntity>(includedProperties, cancellation);
        }

        public Task<TEntity?> GetAsync(Func<TEntity, bool> predicate, CancellationToken cancellation = default)
        {
            return base.GetAsync(predicate, cancellation);
        }

        public Task<TEntity?> GetAsync(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default)
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

        public TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return _context.Find<TEntity>(keyValues);
        }

        public Task<TEntity?> FindAsync<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keyValues).AsTask();
        }

        public Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keyValues, cancellation).AsTask();
        }

        public TEntity? Get<TEntity>(Func<TEntity, bool> predicate) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().SingleOrDefault(predicate);
        }

        public TEntity? Get<TEntity>(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
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

        public TEntity[] GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().ToArray();
        }

        public TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().Include(string.Join(".", includedProperties)).ToArray();
        }

        public Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().ToArrayAsync(cancellation);
        }

        public Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().Include(string.Join(".", includedProperties)).ToArrayAsync(cancellation);
        }

        public Task<TEntity?> GetAsync<TEntity>(Func<TEntity, bool> predicate, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(x => predicate(x), cancellation);
        }

        public async Task<TEntity?> GetAsync<TEntity>(Func<TEntity, bool> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class
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
