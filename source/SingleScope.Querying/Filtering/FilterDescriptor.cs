namespace SingleScope.Querying.Filtering
{
    public sealed class FilterDescriptor
    {
        public string Field { get; }

        public FilterOperator Operator { get; }

        public object? Value { get; }

        public FilterDescriptor(string field, FilterOperator @operator, object? value = null)
        {
            Field = field;
            Operator = @operator;
            Value = value;
        }
    }
}
