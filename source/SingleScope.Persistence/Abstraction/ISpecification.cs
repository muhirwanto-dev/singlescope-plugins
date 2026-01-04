using System.Linq.Expressions;

namespace SingleScope.Persistence.Abstraction
{
    /// <summary>
    /// Defines a contract for the Specification pattern.
    /// Encapsulates query logic including filtering, ordering, and eager loading.
    /// </summary>
    /// <typeparam name="T">The type of the entity the specification is for.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the filter criteria expression (WHERE clause).
        /// </summary>
        Expression<Func<T, bool>>? Criteria { get; }

        /// <summary>
        /// Gets the list of related entities to include (eager loading).
        /// </summary>
        List<Expression<Func<T, object?>>> Includes { get; }

        /// <summary>
        /// Gets the expression for ascending order sorting.
        /// </summary>
        Expression<Func<T, object>>? OrderBy { get; }

        /// <summary>
        /// Gets the expression for descending order sorting.
        /// </summary>
        Expression<Func<T, object>>? OrderByDescending { get; }

        // --- Paging ---

        /// <summary>
        /// Gets the number of records to take (for paging).
        /// </summary>
        int Take { get; }

        /// <summary>
        /// Gets the number of records to skip (for paging).
        /// </summary>
        int Skip { get; }

        /// <summary>
        /// Gets a value indicating whether paging is enabled for this specification.
        /// </summary>
        bool IsPagingEnabled { get; }
    }
}
