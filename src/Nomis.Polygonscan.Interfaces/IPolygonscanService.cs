using Nomis.Polygonscan.Interfaces.Models;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.Polygonscan.Interfaces
{
    /// <summary>
    /// Polygonscan service.
    /// </summary>
    public interface IPolygonscanService :
        IInfrastructureService
    {
        /// <summary>
        /// Client for interacting with Polygonscan API.
        /// </summary>
        public IPolygonscanClient Client { get; }

        /// <summary>
        /// Get polygon wallet stats by address.
        /// </summary>
        /// <param name="address">Polygon wallet address.</param>
        /// <returns>Returns <see cref="PolygonWalletScore"/> result.</returns>
        public Task<Result<PolygonWalletScore>> GetWalletStatsAsync(string address);
    }
}