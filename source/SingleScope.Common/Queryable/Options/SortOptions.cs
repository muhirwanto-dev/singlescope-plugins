namespace SingleScope.Common.Queryable.Options
{
    public sealed class SortOptions
    {
        public required string Field { get; set; }

        public string Direction { get; set; } = Directions.Ascending;

        public static class Directions
        {
            public const string Ascending = "ascending";

            public const string Descending = "descending";
        }
    }
}
