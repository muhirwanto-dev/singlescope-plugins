namespace SingleScope.Querying.Paging
{
    public sealed class PageInfo
    {
        public bool HasNextPage { get; }

        public bool HasPreviousPage { get; }

        public string? StartCursor { get; }

        public string? EndCursor { get; }

        public PageInfo(
            bool hasNextPage,
            bool hasPreviousPage,
            string? startCursor = null,
            string? endCursor = null)
        {
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            StartCursor = startCursor;
            EndCursor = endCursor;
        }
    }
}
