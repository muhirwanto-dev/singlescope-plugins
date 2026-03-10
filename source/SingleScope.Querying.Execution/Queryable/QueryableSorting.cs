using System.Linq;
using SingleScope.Querying.Execution.Internals;
using SingleScope.Querying.Sorting;

namespace SingleScope.Querying.Execution.Queryable
{
    internal static class QueryableSorting
    {
        public static IQueryable<T> Apply<T>(
            IQueryable<T> source,
            SortOptions? sort)
        {
            if (sort == null || sort.Sorts.Count == 0)
                return source;

            IOrderedQueryable<T>? ordered = null;

            foreach (var s in sort.Sorts)
            {
                ordered = ExpressionCache.ApplyOrdering(
                    ordered ?? source,
                    s);
            }

            return ordered ?? source;
        }
    }
}
