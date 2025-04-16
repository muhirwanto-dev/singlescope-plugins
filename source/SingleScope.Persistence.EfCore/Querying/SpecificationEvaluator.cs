using Microsoft.EntityFrameworkCore;
using SingleScope.Persistence.Querying;

namespace SingleScope.Persistence.EFCore.Querying
{
    internal class SpecificationEvaluator : ISpecificationEvaluator
    {
        public IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification, bool evaluateCriteriaOnly = false)
            where TEntity : class
        {
            var query = inputQuery;

            // 1. Apply filtering criteria (WHERE clause)
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Optimization: If only criteria evaluation is needed (for Count/Exists),
            // skip applying includes, ordering, and paging as they don't affect the result
            // and would cause unnecessary work (especially includes).
            if (evaluateCriteriaOnly)
            {
                return query;
            }

            // 2. Apply includes (Eager Loading using Include)
            // Iterates through all include expressions defined in the specification.
            // Aggregate is used to chain the .Include() calls sequentially onto the query.
            // Example: query.Include(o => o.Customer).Include(o => o.OrderItems)
            query = specification.Includes.Aggregate(query,
                                        (current, include) => current.Include(include));

            // 3. Apply ordering (ORDER BY clause)
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            // Otherwise, checks if a descending order is specified.
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            // 4. Apply paging (OFFSET/FETCH or equivalent SQL)
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            // 5. Return the fully constructed IQueryable
            // This IQueryable represents the complete query defined by the specification,
            // ready to be executed against the database (e.g., by calling ToListAsync, FirstOrDefaultAsync).
            return query;
        }
    }
}
