using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using SingleScope.Querying.Filtering;
using SingleScope.Querying.Sorting;

namespace SingleScope.Querying.Execution.Internals
{
    public static class ExpressionCache
    {
        private static readonly ConcurrentDictionary<string, LambdaExpression> Cache
            = new ConcurrentDictionary<string, LambdaExpression>();

        public static Expression<Func<T, bool>>? GetFilterExpression<T>(
            FilterDescriptor filter)
        {
            // simplified: build typed expression like discussed earlier
            // cache by (Type + Field + Operator)
            return DynamicExpressionBuilder.BuildPredicate<T>(filter);
        }

        public static IOrderedQueryable<T> ApplyOrdering<T>(
            IQueryable<T> source,
            SortDescriptor sort)
        {
            return DynamicExpressionBuilder.ApplyOrder(source, sort);
        }
    }
}
