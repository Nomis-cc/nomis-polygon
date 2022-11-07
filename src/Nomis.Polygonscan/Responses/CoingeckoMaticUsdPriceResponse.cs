using System.Text.Json.Serialization;

using Nomis.Coingecko.Interfaces.Models;

namespace Nomis.Polygonscan.Responses
{
    /// <summary>
    /// Coingecko Matic USD price response.
    /// </summary>
    public class CoingeckoMaticUsdPriceResponse :
        ICoingeckoUsdPriceResponse
    {
        /// <inheritdoc cref="CoingeckoUsdPriceData"/>
        [JsonPropertyName("matic-network")]
        public CoingeckoUsdPriceData? Data { get; set; }
    }
}