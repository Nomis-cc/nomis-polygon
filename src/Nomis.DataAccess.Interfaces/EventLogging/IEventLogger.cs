using Nomis.Utils.Contracts.Events;

namespace Nomis.DataAccess.Interfaces.EventLogging
{
    /// <summary>
    /// Event logger.
    /// </summary>
    public interface IEventLogger
    {
        /// <summary>
        /// Save the event.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="event">The event.</param>
        /// <param name="changes">The event changes.</param>
        /// <returns>Returns the number of affected records in the database.</returns>
        Task<int> SaveAsync<TEvent>(TEvent @event, (string? oldValues, string? newValues) changes)
            where TEvent : IEvent;
    }
}