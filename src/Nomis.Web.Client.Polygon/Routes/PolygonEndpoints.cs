using Nomis.Web.Client.Common.Routes;

namespace Nomis.Web.Client.Polygon.Routes
{
    /// <summary>
    /// Polygon endpoints.
    /// </summary>
    public class PolygonEndpoints :
        BaseEndpoints
    {
        /// <summary>
        /// Initialize <see cref="PolygonEndpoints"/>.
        /// </summary>
        /// <param name="baseUrl">Polygon API base URL.</param>
        public PolygonEndpoints(string baseUrl) 
            : base(baseUrl)
        {
        }

        /// <inheritdoc/>
        public override string Blockchain => "polygon";
    }
}
