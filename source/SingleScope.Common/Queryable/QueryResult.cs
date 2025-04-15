namespace SingleScope.Common.Queryable
{
    public class QueryResult<T>
    {
        public ICollection<T>? Data { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public int TotalDataCount { get; set; }
    }
}
