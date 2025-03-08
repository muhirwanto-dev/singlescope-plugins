using Microsoft.EntityFrameworkCore;

namespace SingleScope.Persistence.Repository
{
    public abstract class RepositoryBase<TContext>
        where TContext : DbContext
    {
        protected readonly TContext _context;

        protected RepositoryBase(TContext context)
        {
            _context = context;
        }
    }
}
