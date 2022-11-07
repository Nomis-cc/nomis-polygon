using Nomis.Utils.Contracts.Common;

namespace Nomis.Polygonscan.Interfaces.Settings
{
    /// <summary>
    /// Polygonscan settings.
    /// </summary>
    public class PolygonscanSettings :
        ISettings
    {
        /// <summary>
        /// API key for polygonscan.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.polygonscan.com/"/>
        /// </remarks>
        public string? ApiKey { get; set; }

        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.polygonscan.com/getting-started/endpoint-urls"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }
    }
}