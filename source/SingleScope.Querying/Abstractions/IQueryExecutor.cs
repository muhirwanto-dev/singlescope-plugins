using System.Collections.Generic;

namespace SingleScope.Querying.Abstractions
{
    public interface IQueryExecutor<T>
    {
        QueryResult<T> Execute(Query query, IEnumerable<T> source);
    }
}
