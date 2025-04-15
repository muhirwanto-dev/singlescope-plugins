namespace SingleScope.Common.Queryable.Options
{
    public sealed class PaginationOptions
    {
        public const int FirstPage = 1;

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
