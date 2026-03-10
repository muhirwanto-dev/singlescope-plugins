using System.Threading;
using System.Threading.Tasks;

namespace SingleScope.Querying.Execution.Abstraction
{
    public interface IQueryExecutor<TSource, TResult>
    {
        QueryResult<TResult> Execute(Query query, TSource source);

        Task<QueryResult<TResult>> ExecuteAsync(Query query, TSource source, CancellationToken cancellationToken = default);
    }
}
