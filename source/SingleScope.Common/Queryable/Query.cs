using SingleScope.Common.Queryable.Options;

namespace SingleScope.Common.Queryable
{
    public class Query
    {
        public int Top { get; set; }

        public int Offset { get; set; }

        public PaginationOptions? Pagination { get; set; }

        public FilterOptions? Filter { get; set; }

        public IEnumerable<SortOptions>? Sort { get; set; }
    }
}
