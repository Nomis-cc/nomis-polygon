namespace Nomis.Domain.Contracts
{
    /// <summary>
    /// Business rule.
    /// </summary>
    public interface IBusinessRule
    {
        /// <summary>
        /// Message.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Rule is broken.
        /// </summary>
        /// <returns>Returns true if the business rule is not executed. Otherwise - false.</returns>
        bool IsBroken();
    }
}