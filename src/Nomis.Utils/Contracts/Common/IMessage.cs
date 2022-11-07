namespace Nomis.Utils.Contracts.Common
{
    /// <summary>
    /// Message.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Message type.
        /// </summary>
        string MessageType { get; }

        /// <summary>
        /// Aggregate identifier.
        /// </summary>
        Guid AggregateId { get; }
    }
}