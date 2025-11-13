using System.Linq.Expressions;

namespace SingleScope.Persistence.Specification
{
    public class IncludeSpecification<T> : BaseSpecification<T>
    {
        public IncludeSpecification(Expression<Func<T, object>> include)
        {
            AddInclude(include);
        }

        public IncludeSpecification(IEnumerable<Expression<Func<T, object>>> includes)
        {
            foreach (var include in includes)
            {
                AddInclude(include);
            }
        }
    }
}
