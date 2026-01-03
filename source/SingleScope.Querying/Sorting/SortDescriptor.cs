namespace SingleScope.Querying.Sorting
{
    public sealed class SortDescriptor
    {
        public string Field { get; }

        public SortDirection Direction { get; }

        public SortDescriptor(
            string field,
            SortDirection direction = SortDirection.Asc)
        {
            Field = field;
            Direction = direction;
        }
    }
}
