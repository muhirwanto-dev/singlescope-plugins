using System.Collections.Generic;
using SingleScope.Querying.Executors;

namespace SingleScope.Querying.Extensions
{
    public static class QueryExecutionExtensions
    {
        public static QueryResult<T> Execute<T>(this Query query, IEnumerable<T> source)
            => new EnumerableQueryExecutor<T>().Execute(query, source);
    }
}
