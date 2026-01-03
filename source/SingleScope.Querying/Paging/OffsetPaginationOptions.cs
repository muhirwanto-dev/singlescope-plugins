namespace SingleScope.Querying.Paging
{
    public sealed class OffsetPaginationOptions
    {
        public int Page { get; }

        public int PageSize { get; }

        public int Offset => (Page - 1) * PageSize;

        public OffsetPaginationOptions(
            int page = 1,
            int pageSize = 20)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
