namespace SingleScope.Collection.Queryable.Options
{
    public class GroupOptions
    {
        public required string Field { get; set; }

        public string? Direction { get; set; }

        public IEnumerable<AggregateOptions>? Aggregates { get; set; }
    }
}
