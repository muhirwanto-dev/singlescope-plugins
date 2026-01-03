using SingleScope.Querying.Abstractions;
using SingleScope.Querying.Filtering;
using SingleScope.Querying.Paging;
using SingleScope.Querying.Sorting;

namespace SingleScope.Querying
{
    public sealed class Query : IQuery
    {
        public FilterOptions Filters { get; }

        public SortOptions? Sort { get; }

        public OffsetPaginationOptions? OffsetPaging { get; }

        public CursorPaginationOptions? CursorPaging { get; }

        public bool UsesCursorPaging => CursorPaging != null;

        public bool UsesOffsetPaging => OffsetPaging != null;

        public Query()
        {
            Filters = FilterOptions.Empty;
        }

        public Query(
            SortOptions? sort,
            OffsetPaginationOptions? offsetPaging = null,
            CursorPaginationOptions? cursorPaging = null)
            : this(FilterOptions.Empty, sort, offsetPaging, cursorPaging)
        {
        }

        public Query(
            FilterOptions filters,
            SortOptions? sort = null,
            OffsetPaginationOptions? offsetPaging = null,
            CursorPaginationOptions? cursorPaging = null)
        {
            Filters = filters;
            Sort = sort;
            OffsetPaging = offsetPaging;
            CursorPaging = cursorPaging;
        }
    }
}
