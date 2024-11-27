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

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return base.GetAllAsync<TEntity>();
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

        public virtual Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
