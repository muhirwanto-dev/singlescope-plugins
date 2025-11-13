using System.Linq.Expressions;

namespace SingleScope.Persistence.Specification
{
    public class PagingSpecification<T> : BaseSpecification<T>
    {
        public PagingSpecification(int skip, int take)
        {
            ApplyPaging(skip, take);
        }

        public PagingSpecification(int skip, int take, Expression<Func<T, object>> include)
        {
            ApplyPaging(skip, take);
            AddInclude(include);
        }

        public PagingSpecification(int skip, int take, IEnumerable<Expression<Func<T, object>>> includes)
        {
            ApplyPaging(skip, take);

            foreach (var include in includes)
            {
                AddInclude(include);
            }
        }
    }
}
