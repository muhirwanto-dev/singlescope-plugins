using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SingleScope.Querying.Filtering;
using SingleScope.Querying.Paging;
using SingleScope.Querying.Sorting;

namespace SingleScope.Querying.Executors
{
    public sealed class EnumerableQueryExecutor<T>
    {
        public QueryResult<T> Execute(Query query, IEnumerable<T> source)
        {
            var data = source;

            data = ApplyFiltering(data, query.Filters);
            data = ApplySorting(data, query.Sort);

            return ApplyPaging(data, query);
        }

        private static IEnumerable<T> ApplyFiltering(IEnumerable<T> source, FilterOptions filters)
        {
            foreach (var filter in filters.Filters)
            {
                var property = typeof(T).GetProperty(filter.Field);
                if (property == null)
                {
                    continue;
                }

                source = source.Where(item =>
                {
                    var value = property.GetValue(item);
                    var comparison = Compare(value, filter.Value);

                    return filter.Operator switch
                    {
                        FilterOperator.Equals =>
                            Equals(value, filter.Value),

                        FilterOperator.NotEquals =>
                            !Equals(value, filter.Value),

                        FilterOperator.GreaterThan =>
                            comparison > 0,

                        FilterOperator.GreaterThanOrEqual =>
                            comparison >= 0,

                        FilterOperator.LessThan =>
                            comparison < 0,

                        FilterOperator.LessThanOrEqual =>
                            comparison <= 0,

                        FilterOperator.Contains =>
                            StringMatch(value, filter.Value, (a, b) =>
                                a.Contains(b, StringComparison.OrdinalIgnoreCase)),

                        FilterOperator.StartsWith =>
                            StringMatch(value, filter.Value, (a, b) =>
                                a.StartsWith(b, StringComparison.OrdinalIgnoreCase)),

                        FilterOperator.EndsWith =>
                            StringMatch(value, filter.Value, (a, b) =>
                                a.EndsWith(b, StringComparison.OrdinalIgnoreCase)),

                        FilterOperator.In =>
                            filter.Value is IEnumerable values &&
                            values.Cast<object?>().Any(v => Equals(value, v)),

                        _ => true
                    };
                });
            }

            return source;
        }

        private static IEnumerable<T> ApplySorting(IEnumerable<T> source, SortOptions? sort)
        {
            if (sort == null || sort.Sorts.Count == 0)
            {
                return source;
            }

            IOrderedEnumerable<T>? ordered = null;

            foreach (var s in sort.Sorts)
            {
                var prop = typeof(T).GetProperty(s.Field);
                if (prop == null)
                {
                    continue;
                }

                ordered = ordered == null
                    ? s.Direction == SortDirection.Asc
                        ? source.OrderBy(x => prop.GetValue(x))
                        : source.OrderByDescending(x => prop.GetValue(x))
                    : s.Direction == SortDirection.Asc
                        ? ordered.ThenBy(x => prop.GetValue(x))
                        : ordered.ThenByDescending(x => prop.GetValue(x));
            }

            return ordered ?? source;
        }

        private static QueryResult<T> ApplyPaging(
            IEnumerable<T> source,
            Query query)
        {
            if (query.UsesCursorPaging)
            {
                var paging = query.CursorPaging;
                var prop = typeof(T).GetProperty(paging.CursorField)
                    ?? throw new InvalidOperationException(
                        $"Cursor field '{paging.CursorField}' not found on type '{typeof(T).Name}'.");

                if (!string.IsNullOrEmpty(paging.Cursor))
                {
                    var cursorValue = CursorEncryption.DecodeCursor(paging.Cursor, prop.PropertyType);

                    source = paging.Direction == CursorDirection.Forward
                        ? source.Where(x =>
                            Comparer.Default.Compare(prop.GetValue(x), cursorValue) > 0)
                        : source.Where(x =>
                            Comparer.Default.Compare(prop.GetValue(x), cursorValue) < 0);
                }

                // Fetch limit + 1 to detect next page
                var items = source.Take(paging.Limit + 1).ToList();
                var hasNext = items.Count > paging.Limit;
                var result = items.Take(paging.Limit).ToList();

                var endCursor = result.Count > 0
                    ? CursorEncryption.EncodeCursor(prop.GetValue(result.Last())!)
                    : null;

                return new QueryResult<T>(
                    result,
                    totalDataCount: -1, // 🚨 cursor paging must NOT expose total count
                    pageInfo: new PageInfo(
                        hasNextPage: hasNext,
                        hasPreviousPage: paging.Cursor != null,
                        startCursor: paging.Cursor,
                        endCursor: endCursor
                    )
                );
            }

            // Offset paging fallback
            int totalCount = source.Count();

            if (query.UsesOffsetPaging)
            {
                var paged = source
                    .Skip(query.OffsetPaging!.Offset)
                    .Take(query.OffsetPaging!.PageSize)
                    .ToList();

                return new QueryResult<T>(paged, totalCount);
            }

            return new QueryResult<T>(source.ToList(), totalCount);
        }

        private static int? Compare(object? left, object? right)
        {
            if (left == null || right == null)
            {
                return null;
            }

            if (left is IComparable comparable)
            {
                var converted = Convert.ChangeType(right, left.GetType(), CultureInfo.InvariantCulture);
                return comparable.CompareTo(converted);
            }

            return null;
        }

        private static bool StringMatch(object? value, object? filterValue, Func<string, string, bool> matcher)
        {
            if (value == null || filterValue == null)
            {
                return false;
            }

            return matcher(value.ToString()!, filterValue.ToString()!);
        }
    }
}
