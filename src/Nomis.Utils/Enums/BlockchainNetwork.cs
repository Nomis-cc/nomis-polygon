// ReSharper disable InconsistentNaming

namespace Nomis.Utils.Enums
{
    /// <summary>
    /// Blockchain network.
    /// </summary>
    /// <remarks>
    /// The chain Id of the network is used as the value.
    /// If the network does not have a chain Id, then 11111x value is used, where x is a sequence number.
    /// </remarks>
    public enum BlockchainNetwork
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Polygon.
        /// </summary>
        Polygon = 137,

    }
}