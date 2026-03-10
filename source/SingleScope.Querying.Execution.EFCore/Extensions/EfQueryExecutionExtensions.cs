using SingleScope.Querying.Execution.EFCore.Queryable;

namespace SingleScope.Querying.Execution.EFCore.Extensions
{
    public static class EfQueryExecutionExtensions
    {
        public static QueryResult<T> Execute<T>(
            this Query query,
            IQueryable<T> source)
            => new EfQueryableQueryExecutor<T>().Execute(query, source);

        public static Task<QueryResult<T>> ExecuteAsync<T>(
            this Query query,
            IQueryable<T> source,
            CancellationToken cancellationToken = default)
            => new EfQueryableQueryExecutor<T>().ExecuteAsync(query, source, cancellationToken);
    }
}
