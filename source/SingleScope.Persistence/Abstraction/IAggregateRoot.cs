namespace SingleScope.Persistence.Abstraction
{
    /// <summary>
    /// Represents the root entity of an aggregate in a domain-driven design context.
    /// </summary>
    /// <remarks>An aggregate root is responsible for maintaining the consistency of changes within the
    /// aggregate. All access to the aggregate's entities should be performed through the aggregate root to enforce
    /// invariants and encapsulate business logic.</remarks>
    public interface IAggregateRoot;
}
