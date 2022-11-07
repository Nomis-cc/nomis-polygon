using Nomis.Polygonscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Managers;

namespace Nomis.Web.Client.Polygon.Managers
{
    /// <summary>
    /// Polygon manager.
    /// </summary>
    public interface IPolygonManager :
        IManager
    {
        /// <summary>
        /// Get polygon wallet score.
        /// </summary>
        /// <param name="address">Wallet address.</param>
        /// <returns>Returns result of <see cref="PolygonWalletScore"/>.</returns>
        Task<IResult<PolygonWalletScore>> GetWalletScoreAsync(string address);
    }
}