namespace SingleScope.Collection.Queryable
{
    public class QueryResult<T>
    {
        public ICollection<T>? Data { get; set; }

        public int Total { get; set; }
    }
}
