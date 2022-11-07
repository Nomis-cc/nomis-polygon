using Nomis.Domain.Exceptions;

namespace Nomis.Domain.Contracts
{
    /// <summary>
    /// Supports checking <see cref="IBusinessRule"/>.
    /// </summary>
    public interface ISupportsCheckingRules
    {
        /// <summary>
        /// Check business rule.
        /// </summary>
        /// <param name="rule">Business rule.</param>
        public virtual void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}