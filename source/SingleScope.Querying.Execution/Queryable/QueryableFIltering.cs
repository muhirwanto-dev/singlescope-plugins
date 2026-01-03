using System.Linq;
using SingleScope.Querying.Execution.Internals;
using SingleScope.Querying.Filtering;

namespace SingleScope.Querying.Execution.Queryable
{
    internal static class QueryableFiltering
    {
        public static IQueryable<T> Apply<T>(
            IQueryable<T> source,
            FilterOptions filters)
        {
            foreach (var filter in filters.Filters)
            {
                var expr = ExpressionCache.GetFilterExpression<T>(filter);
                if (expr != null)
                {
                    source = source.Where(expr);
                }
            }

            return source;
        }
    }
}
