using System;
using System.Collections.Generic;
using SingleScope.Querying.Abstractions;
using SingleScope.Querying.Paging;

namespace SingleScope.Querying
{
    public sealed class QueryResult<T> : IQueryResult<T>
    {
        public IReadOnlyList<T> Items { get; }

        public int TotalDataCount { get; }

        /// <summary>
        /// Cursor pagination metadata (null for offset paging).
        /// </summary>
        public PageInfo? PageInfo { get; }

        public QueryResult()
            : this(Array.Empty<T>(), 0, null)
        {
        }

        public QueryResult(int totalDataCount = 0)
            : this(Array.Empty<T>(), totalDataCount, null)
        {
        }

        public QueryResult(IReadOnlyList<T> items, int totalDataCount = 0, PageInfo? pageInfo = null)
        {
            Items = items;
            TotalDataCount = totalDataCount;
            PageInfo = pageInfo;
        }
    }
}
