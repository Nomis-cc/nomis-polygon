using Nomis.Utils.Contracts.Properties;

namespace Nomis.Utils.Contracts.Common
{
    /// <inheritdoc cref="IEntity"/>
    /// <typeparam name="TEntityId">The entity identifier type.</typeparam>
    public interface IEntity<out TEntityId> :
        IEntity,
        IHasId<TEntityId>
    {
        /// <summary>
        /// Entity identifier.
        /// </summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public new TEntityId Id { get; }
    }

    /// <summary>
    /// Entity.
    /// </summary>
    public interface IEntity
    {
    }
}