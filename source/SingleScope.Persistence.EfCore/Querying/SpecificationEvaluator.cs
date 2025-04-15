using Microsoft.EntityFrameworkCore;
using SingleScope.Persistence.Querying;

namespace SingleScope.Persistence.EfCore.Querying
{
    internal class SpecificationEvaluator : ISpecificationEvaluator
    {
        public IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification, bool evaluateCriteriaOnly = false)
            where TEntity : class
        {
            var query = inputQuery;

            // 1. Apply filtering criteria (WHERE clause)
            // Checks if the specification defines a filter condition.
            if (specification.Criteria != null)
            {
                // Applies the filter using LINQ's Where extension method.
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
            // Checks if an ascending order is specified.
            if (specification.OrderBy != null)
            {
                // Applies sorting using LINQ's OrderBy extension method.
                query = query.OrderBy(specification.OrderBy);
            }
            // Otherwise, checks if a descending order is specified.
            else if (specification.OrderByDescending != null)
            {
                // Applies sorting using LINQ's OrderByDescending extension method.
                query = query.OrderByDescending(specification.OrderByDescending);
            }
            // Note: If both OrderBy and OrderByDescending were set (which BaseSpecification prevents),
            // the last one applied would take precedence based on this logic.

            // 4. Apply paging (OFFSET/FETCH or equivalent SQL)
            // Checks if the specification has requested paging.
            if (specification.IsPagingEnabled)
            {
                // Applies paging using LINQ's Skip and Take extension methods.
                // Skip specifies how many records to bypass.
                // Take specifies the maximum number of records to return.
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            // 5. Return the fully constructed IQueryable
            // This IQueryable represents the complete query defined by the specification,
            // ready to be executed against the database (e.g., by calling ToListAsync, FirstOrDefaultAsync).
            return query;
        }
    }
}
