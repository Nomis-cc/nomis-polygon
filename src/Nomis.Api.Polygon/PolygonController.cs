using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomis.Api.Polygon.Abstractions;
using Nomis.Polygonscan.Interfaces;
using Nomis.Polygonscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Polygon
{
    /// <summary>
    /// A controller to aggregate all Polygon-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Polygon.")]
    internal sealed partial class PolygonController :
        PolygonBaseController
    {
        private readonly ILogger<PolygonController> _logger;
        private readonly IPolygonscanService _polygonscanService;

        /// <summary>
        /// Initialize <see cref="PolygonController"/>.
        /// </summary>
        /// <param name="polygonscanService"><see cref="IPolygonscanService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public PolygonController(
            IPolygonscanService polygonscanService,
            ILogger<PolygonController> logger)
        {
            _polygonscanService = polygonscanService ?? throw new ArgumentNullException(nameof(polygonscanService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get Nomis Score for given wallet address.
        /// </summary>
        /// <param name="address" example="0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae">Polygon wallet address to get Nomis Score.</param>
        /// <returns>An Nomis Score value and corresponding statistical data.</returns>
        /// <remarks>
        /// Sample request:
        ///     GET /api/v1/polygon/wallet/0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae/score
        /// </remarks>
        /// <response code="200">Returns Nomis Score and stats.</response>
        /// <response code="400">Address not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("wallet/{address}/score", Name = "GetPolygonWalletScore")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetPolygonWalletScore",
            Tags = new[] { PolygonTag })]
        [ProducesResponseType(typeof(Result<PolygonWalletScore>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetPolygonWalletScoreAsync(
            [Required(ErrorMessage = "Wallet address should be set")] string address)
        {
            var result = await _polygonscanService.GetWalletStatsAsync(address);
            return Ok(result);
        }
    }
}