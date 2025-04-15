using System.Linq.Expressions;

namespace SingleScope.Persistence.Querying
{
    /// <summary>
    /// Base class for creating specifications, implementing ISpecification<T>.
    /// Provides helper methods to build the specification criteria.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSpecification{T}"/> class.
        /// Used when no initial criteria are needed.
        /// </summary>
        protected BaseSpecification() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSpecification{T}"/> class
        /// with initial filter criteria.
        /// </summary>
        /// <param name="criteria">The initial filter expression.</param>
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// <inheritdoc/>
        public Expression<Func<T, bool>>? Criteria { get; private set; }

        /// <inheritdoc/>
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        /// <inheritdoc/>
        public Expression<Func<T, object>>? OrderBy { get; private set; }

        /// <summary>
        /// Defines a contract for the Specification pattern.
        /// Encapsulates query logic including filtering, ordering, and eager loading.
        /// </summary>
        /// <typeparam name="T">The type of the entity the specification is for.</typeparam>
        /// <inheritdoc/>
        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        /// <inheritdoc/>
        public int Take { get; private set; }

        /// <inheritdoc/>
        public int Skip { get; private set; }

        /// <inheritdoc/>
        public bool IsPagingEnabled { get; private set; } = false;


        // --- Protected helper methods for building the specification ---

        /// <summary>
        /// Adds an include expression for eager loading related data.
        /// </summary>
        /// <param name="includeExpression">The expression specifying the related data to include.</param>
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        // Optional: AddInclude for string-based includes if needed
        // protected virtual void AddInclude(string includeString) { ... }

        /// <summary>
        /// Applies ascending sorting based on the specified expression.
        /// </summary>
        /// <param name="orderByExpression">The expression to sort by.</param>
        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
            OrderByDescending = null; // Ensure only one order direction is set
        }

        /// <summary>
        /// Applies descending sorting based on the specified expression.
        /// </summary>
        /// <param name="orderByDescendingExpression">The expression to sort by.</param>
        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
            OrderBy = null; // Ensure only one order direction is set
        }

        /// <summary>
        /// Applies paging to the query.
        /// </summary>
        /// <param name="skip">Number of records to skip.</param>
        /// <param name="take">Number of records to take.</param>
        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        /// <summary>
        /// Sets the filter criteria for the specification.
        /// Note: Use the constructor or combine expressions manually if needed.
        /// This method replaces any existing criteria.
        /// </summary>
        /// <param name="criteria">The filter expression.</param>
        protected virtual void SetCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
    }

    /*
    // --- Example Usage ---

    // Assume you have an Order entity
    public class Order : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // Navigation property
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Navigation property
    }

    public class Customer : IEntity<int> { public int Id { get; set; } public string Name { get; set; } }
    public class OrderItem : IEntity<int> { public int Id { get; set; } public int OrderId { get; set; } public string ProductName { get; set; } }


    // Example Specification: Get recent orders over a certain amount, including customer and items, ordered by date descending.
    public class RecentHighValueOrdersSpecification : BaseSpecification<Order>
    {
        public RecentHighValueOrdersSpecification(decimal minAmount, DateTime minDate)
            : base(o => o.TotalAmount > minAmount && o.OrderDate >= minDate) // Set initial criteria via constructor
        {
            // Add includes for related entities
            AddInclude(o => o.Customer);
            AddInclude(o => o.OrderItems);

            // Apply sorting
            ApplyOrderByDescending(o => o.OrderDate);

            // Optionally apply paging
            // ApplyPaging(0, 10); // Get the first 10
        }
    }

    // --- How you might use it in a service/handler ---
    // var spec = new RecentHighValueOrdersSpecification(100m, DateTime.UtcNow.AddDays(-30));
    // IReadOnlyList<Order> orders = await _orderRepository.FindAsync(spec); // Assuming FindAsync accepts ISpecification
    */
}
