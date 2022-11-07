using Nomis.Utils.Contracts.Common;

namespace Nomis.Blockchain.Abstractions.Settings
{
    /// <summary>
    /// API visibility settings.
    /// </summary>
    public class ApiVisibilitySettings
        : ISettings
    {
        /// <summary>
        /// Polygon API is enabled.
        /// </summary>
        public bool PolygonAPIEnabled { get; set; }

    }
}