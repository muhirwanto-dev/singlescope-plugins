using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SingleScope.Persistence.Repository
{
    public abstract class ReadOnlyRepository<TContext, TEntity> : RepositoryBase<TContext>, IReadOnlyRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public ReadOnlyRepository(TContext context) : base(context)
        {
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Query().SingleOrDefault(predicate);
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null)
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

        public TEntity[] GetAll()
        {
            return Query().ToArray();
        }

        public TEntity[] GetAll(string[] includedProperties)
        {
            return Query().Include(string.Join(".", includedProperties)).ToArray();
        }

        public TEntity? Find(params object?[]? keyValues)
        {
            return _context.Find<TEntity>(keyValues);
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default)
        {
            return Query().SingleOrDefaultAsync(predicate, cancellation);
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default)
        {
            return Query().SingleOrDefaultAsync(predicate, cancellation);
        }

        public Task<TEntity[]> GetAllAsync(CancellationToken cancellation = default)
        {
            return Query().AsNoTracking().ToArrayAsync(cancellation);
        }

        public Task<TEntity[]> GetAllAsync(string[] includedProperties, CancellationToken cancellation = default)
        {
            return Query().Include(string.Join(".", includedProperties)).ToArrayAsync(cancellation);
        }

        public Task<TEntity?> FindAsync(object? keyValue, CancellationToken cancellation = default)
        {
            return _context.FindAsync<TEntity>(keyValue, cancellation).AsTask();
        }

        public Task<TEntity?> FindAsync(object?[]? keyValues, CancellationToken cancellation = default)
        {
            return _context.FindAsync<TEntity>(keyValues, cancellation).AsTask();
        }
    }

    public abstract class ReadOnlyRepository<TContext> : RepositoryBase<TContext>, IReadOnlyRepository
        where TContext : DbContext
    {
        public ReadOnlyRepository(TContext context) : base(context)
        {
        }

        public TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().SingleOrDefault(predicate);
        }

        public TEntity? Get<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null) where TEntity : class
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
            return Query<TEntity>().ToArray();
        }

        public TEntity[] GetAll<TEntity>(string[] includedProperties) where TEntity : class
        {
            return Query<TEntity>().Include(string.Join(".", includedProperties)).ToArray();
        }

        public TEntity? Find<TEntity>(params object?[]? keyValues) where TEntity : class
        {
            return _context.Find<TEntity>(keyValues);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default) where TEntity : class
        {
            return Query<TEntity>().SingleOrDefaultAsync(predicate, cancellation);
        }

        public async Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string[] includedProperties, string[]? includedCollections = null, CancellationToken cancellation = default) where TEntity : class
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

        public Task<TEntity[]> GetAllAsync<TEntity>(CancellationToken cancellation = default) where TEntity : class
        {
            return Query<TEntity>().ToArrayAsync(cancellation);
        }

        public Task<TEntity[]> GetAllAsync<TEntity>(string[] includedProperties, CancellationToken cancellation = default) where TEntity : class
        {
            return Query<TEntity>().Include(string.Join(".", includedProperties)).ToArrayAsync(cancellation);
        }

        public Task<TEntity?> FindAsync<TEntity>(object? keyValue, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keyValue, cancellation).AsTask();
        }

        public Task<TEntity?> FindAsync<TEntity>(object?[]? keyValues, CancellationToken cancellation = default) where TEntity : class
        {
            return _context.FindAsync<TEntity>(keyValues, cancellation).AsTask();
        }
    }
}
