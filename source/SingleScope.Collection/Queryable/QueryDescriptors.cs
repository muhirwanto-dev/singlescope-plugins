using System.Linq.Expressions;
using System.Text.Json;
using SingleScope.Collection.Queryable.Options;
using SingleScope.Core.Extensions;

namespace SingleScope.Collection.Queryable
{
    public static class QueryDescriptors
    {
        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, FilterOptions filter)
        {
            if (filter == null)
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var expression = BuildFilterExpression<T>(filter, parameter);

            if (expression != null)
            {
                var lambda = Expression.Lambda<Func<T, bool>>(expression, parameter);
                query = query.Where(lambda);
            }

            return query;
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IEnumerable<SortOptions> sortOptions)
        {
            if (sortOptions == null || !sortOptions.Any())
            {
                return query;
            }

            bool isFirstSort = true;
            var bindingFlags = System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;

            foreach (var sort in sortOptions)
            {
                if (isFirstSort)
                {
                    query = sort.Direction == SortOptions.Directions.Ascending
                        ? query.OrderBy(e => e!.GetType().GetProperty(sort.Field, bindingFlags)!.GetValue(e))
                        : query.OrderByDescending(e => e!.GetType().GetProperty(sort.Field, bindingFlags)!.GetValue(e));

                    isFirstSort = false;
                }
                else
                {
                    query = sort.Direction == SortOptions.Directions.Ascending
                        ? ((IOrderedQueryable<T>)query).ThenBy(e => e!.GetType().GetProperty(sort.Field, bindingFlags)!.GetValue(e))
                        : ((IOrderedQueryable<T>)query).ThenByDescending(e => e!.GetType().GetProperty(sort.Field, bindingFlags)!.GetValue(e));
                }
            }

            return query;
        }

        public static IQueryable<T> ApplyQuery<T>(this IQueryable<T> query, Query request)
        {
            // Apply filtering
            if (request.Filter != null)
            {
                query = query.ApplyFiltering(request.Filter);
            }

            // Apply grouping
            if (request.Group != null)
            {
                // Note: Grouping logic needs specific handling as it changes the query type.
                // For simplicity, skipping direct integration here.
                throw new NotImplementedException();
            }

            // Apply sorting
            if (request.Sort != null)
            {
                query = query.ApplySorting(request.Sort);
            }

            // Apply paging
            if (request.Pagination != null)
            {
                if (request.Pagination.Page > 0 && request.Pagination.PageSize > 0)
                {
                    query = query.Skip((request.Pagination.Page - 1) * request.Pagination.PageSize).Take(request.Pagination.PageSize);
                }
            }
            else
            {
                query = query.Skip(request.Offset).Take(request.Top);
            }

            return query;
        }

        public static QueryResult<T> ApplyQueryAsResult<T>(this IQueryable<T> query, Query request)
        {
            int total = query.Count();

            return new QueryResult<T>
            {
                Data = query.ApplyQuery(request).ToArray(),
                Total = total,
            };
        }

        private static Expression? BuildFilterExpression<T>(FilterOptions filter, ParameterExpression parameter)
        {
            // Composite filter
            if (filter.Filters != null && filter.Filters.Any())
            {
                var expressions = filter.Filters
                    .Select(f => BuildFilterExpression<T>(f, parameter))
                    .Where(e => e != null)
                    // convert List<Expression?> to List<Expression>
                    .Select(e => e!)
                    .ToList();

                if (!expressions.Any())
                {
                    return null;
                }

                // Combine expressions using the specified logical operator
                return filter.Logic switch
                {
                    FilterOptions.Logics.Or => expressions.Aggregate(Expression.OrElse),
                    _ => expressions.Aggregate(Expression.AndAlso),
                };
            }
            // Single filter
            else
            {
                var objValue = filter.Value;

                if (objValue is JsonElement element)
                {
                    objValue = element.GetValueAsObject();
                }

                var property = Expression.Property(parameter, filter.Field ?? string.Empty);
                var constant = Expression.Constant(Convert.ChangeType(objValue, property.Type));

                return filter.Operator switch
                {
                    FilterOptions.Operators.Equal => Expression.Equal(property, constant),
                    FilterOptions.Operators.NotEqual => Expression.NotEqual(property, constant),
                    FilterOptions.Operators.LessThan => Expression.LessThan(property, constant),
                    FilterOptions.Operators.LessThanOrEqual => Expression.LessThanOrEqual(property, constant),
                    FilterOptions.Operators.GreaterThan => Expression.GreaterThan(property, constant),
                    FilterOptions.Operators.GreaterThanOrEqual => Expression.GreaterThanOrEqual(property, constant),
                    FilterOptions.Operators.Contains => Expression.Call(property, "Contains", null, constant),
                    FilterOptions.Operators.StartsWith => Expression.Call(property, "StartsWith", null, constant),
                    FilterOptions.Operators.EndsWith => Expression.Call(property, "EndsWith", null, constant),
                    _ => throw new NotSupportedException($"Filter operator '{filter.Operator}' is not supported.")
                };
            }
        }
    }
}
