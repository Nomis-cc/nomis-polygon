namespace Nomis.Domain.Contracts
{
    /// <inheritdoc cref="IAggregateRoot"/>
    /// <typeparam name="TAggregateRootId">Aggregate root identifier type.</typeparam>
    public interface IAggregateRoot<out TAggregateRootId> :
        IAggregate<TAggregateRootId>
    {
    }

    /// <summary>
    /// Aggregate root.
    /// </summary>
    public interface IAggregateRoot
        : IAggregate
    {
    }
}