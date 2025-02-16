namespace SingleScope.Collection.Queryable.Options
{
    public class FilterOptions
    {
        public string? Field { get; set; }

        public string? Operator { get; set; }

        public object? Value { get; set; }

        public string? Logic { get; set; }

        public FilterOptions[]? Filters { get; set; }

        public static class Operators
        {
            public const string Equal = "eq";

            public const string NotEqual = "neq";

            public const string LessThan = "lt";

            public const string LessThanOrEqual = "lte";

            public const string GreaterThan = "gt";

            public const string GreaterThanOrEqual = "gte";

            public const string Contains = "contains";

            public const string StartsWith = "startswith";

            public const string EndsWith = "endswith";
        }

        public static class Logics
        {
            public const string And = "and";

            public const string Or = "or";
        }
    }
}
