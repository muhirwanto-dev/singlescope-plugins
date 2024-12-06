using SingleScope.Collection.Queryable.Options;

namespace SingleScope.Collection.Queryable
{
    public class Query
    {
        public int Top { get; set; }

        public int Offset { get; set; }

        public PaginationOptions? Pagination { get; set; }

        public FilterOptions? Filter { get; set; }

        public IEnumerable<SortOptions>? Sort { get; set; }

        public IEnumerable<GroupOptions>? Group { get; set; }
    }
}
