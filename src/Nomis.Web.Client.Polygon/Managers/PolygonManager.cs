using Microsoft.Extensions.Options;
using Nomis.Polygonscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Extensions;
using Nomis.Web.Client.Common.Settings;
using Nomis.Web.Client.Polygon.Routes;

namespace Nomis.Web.Client.Polygon.Managers
{
    /// <inheritdoc cref="IPolygonManager" />
    public class PolygonManager :
        IPolygonManager
    {
        private readonly HttpClient _httpClient;
        private readonly PolygonEndpoints _endpoints;

        /// <summary>
        /// Initialize <see cref="PolygonManager"/>.
        /// </summary>
        /// <param name="webApiSettings"><see cref="WebApiSettings"/>.</param>
        public PolygonManager(
            IOptions<WebApiSettings> webApiSettings)
        {
            _httpClient = new()
            {
                BaseAddress = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)))
            };
            _endpoints = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)));
        }

        /// <inheritdoc />
        public async Task<IResult<PolygonWalletScore>> GetWalletScoreAsync(string address)
        {
            var response = await _httpClient.GetAsync(_endpoints.GetWalletScore(address));
            return await response.ToResultAsync<PolygonWalletScore>();
        }
    }
}