using System.Collections.Generic;

namespace SingleScope.Querying.Abstractions
{
    public interface IQueryResult<out T>
    {
        IReadOnlyList<T> Items { get; }
    }
}
