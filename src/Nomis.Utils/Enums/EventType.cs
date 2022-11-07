namespace Nomis.Utils.Enums
{
    /// <summary>
    /// Event type.
    /// </summary>
    public enum EventType :
        byte
    {
        /// <summary>
        /// Unknown event.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Domain event.
        /// </summary>
        Domain = 1,

        /// <summary>
        /// Application event.
        /// </summary>
        Application = 2
    }
}