using Nomis.Utils.Contracts.Common;

namespace Nomis.Domain.Contracts
{
    /// <summary>
    /// Domain entity.
    /// </summary>
    public interface IDomainEntity :
        IEntity,
        IGeneratesDomainEvents,
        ISupportsCheckingRules
    {
    }
}