using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingleScope.Querying.Abstractions
{
    public interface IQueryExecutor<T>
    {
        QueryResult<T> Execute(Query query, IEnumerable<T> source);

        Task<QueryResult<T>> ExecuteAsync(Query query, IEnumerable<T> source, CancellationToken cancellationToken = default);
    }
}
