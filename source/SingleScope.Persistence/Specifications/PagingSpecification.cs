using System.Linq.Expressions;
using SingleScope.Persistence.Specifications;

namespace SingleScope.Persistence.Specification
{
    public class PagingSpecification<T> : BaseSpecification<T>
    {
        public PagingSpecification(int skip, int take)
        {
            ApplyPaging(skip, take);
        }

        public PagingSpecification(int skip, int take, Expression<Func<T, bool>> criteria)
            : base(criteria)
        {
            ApplyPaging(skip, take);
        }
    }
}
