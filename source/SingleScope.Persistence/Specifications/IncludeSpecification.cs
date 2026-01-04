using System.Linq.Expressions;
using SingleScope.Persistence.Specifications;

namespace SingleScope.Persistence.Specification
{
    public class IncludeSpecification<T> : BaseSpecification<T>
    {
        public IncludeSpecification(Expression<Func<T, object?>> include)
        {
            AddInclude(include);
        }

        public IncludeSpecification(IEnumerable<Expression<Func<T, object?>>> includes)
        {
            foreach (var include in includes)
            {
                AddInclude(include);
            }
        }

        public IncludeSpecification(Expression<Func<T, bool>> criteria, Expression<Func<T, object?>> include)
            : this(include)
        {
            SetCriteria(criteria);
        }

        public IncludeSpecification(Expression<Func<T, bool>> criteria, IEnumerable<Expression<Func<T, object?>>> includes)
            : this(includes)
        {
            SetCriteria(criteria);
        }
    }
}
