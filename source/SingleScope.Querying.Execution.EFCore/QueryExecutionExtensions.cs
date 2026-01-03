namespace SingleScope.Querying.Execution.EFCore
{
    public static class QueryExecutionExtensions
    {
        public static QueryResult<T> Execute<T>(this Query query, IQueryable<T> source)
            => new QueryableQueryExecutor<T>().Execute(query, source);
    }
}
