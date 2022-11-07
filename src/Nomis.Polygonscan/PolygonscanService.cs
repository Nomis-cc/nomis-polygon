using System.Net;
using System.Text.Json;

using Nethereum.Util;
using Nomis.Coingecko.Interfaces;
using Nomis.Domain.Scoring.Entities;
using Nomis.Polygonscan.Calculators;
using Nomis.Polygonscan.Interfaces;
using Nomis.Polygonscan.Interfaces.Extensions;
using Nomis.Polygonscan.Interfaces.Models;
using Nomis.Polygonscan.Responses;
using Nomis.ScoringService.Interfaces;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Enums;
using Nomis.Utils.Exceptions;
using Nomis.Utils.Wrapper;

namespace Nomis.Polygonscan
{
    /// <inheritdoc cref="IPolygonscanService"/>
    internal sealed class PolygonscanService :
        IPolygonscanService,
        ITransientService
    {
        private readonly ICoingeckoService _coingeckoService;
        private readonly IScoringService _scoringService;

        /// <summary>
        /// Initialize <see cref="PolygonscanService"/>.
        /// </summary>
        /// <param name="client"><see cref="IPolygonscanClient"/>.</param>
        /// <param name="coingeckoService"><see cref="ICoingeckoService"/>.</param>
        /// <param name="scoringService"><see cref="IScoringService"/>.</param>
        public PolygonscanService(
            IPolygonscanClient client,
            ICoingeckoService coingeckoService,
            IScoringService scoringService)
        {
            _coingeckoService = coingeckoService;
            _scoringService = scoringService;
            Client = client;
        }

        /// <inheritdoc/>
        public IPolygonscanClient Client { get; }

        /// <inheritdoc/>
        public async Task<Result<PolygonWalletScore>> GetWalletStatsAsync(string address)
        {
            if (!new AddressUtil().IsValidAddressLength(address) || !new AddressUtil().IsValidEthereumAddressHexFormat(address))
            {
                throw new CustomException("Invalid address", statusCode: HttpStatusCode.BadRequest);
            }

            var balanceWei = (await Client.GetBalanceAsync(address)).Balance;
            var usdBalance = await _coingeckoService.GetUsdBalanceAsync<CoingeckoMaticUsdPriceResponse>(balanceWei?.ToMatic() ?? 0, "matic-network");
            var transactions = (await Client.GetTransactionsAsync<PolygonscanAccountNormalTransactions, PolygonscanAccountNormalTransaction>(address)).ToList();
            var internalTransactions = (await Client.GetTransactionsAsync<PolygonscanAccountInternalTransactions, PolygonscanAccountInternalTransaction>(address)).ToList();
            var erc20Tokens = (await Client.GetTransactionsAsync<PolygonscanAccountERC20TokenEvents, PolygonscanAccountERC20TokenEvent>(address)).ToList();
            var erc721Tokens = (await Client.GetTransactionsAsync<PolygonscanAccountERC721TokenEvents, PolygonscanAccountERC721TokenEvent>(address)).ToList();
            var erc1155Tokens = (await Client.GetTransactionsAsync<PolygonscanAccountERC1155TokenEvents, PolygonscanAccountERC1155TokenEvent>(address)).ToList();

            var tokens = new List<IPolygonscanAccountNftTokenEvent>();
            tokens.AddRange(erc721Tokens);
            tokens.AddRange(erc1155Tokens);

            var walletStats = new PolygonStatCalculator(
                    address,
                    decimal.TryParse(balanceWei, out var wei) ? wei : 0,
                    usdBalance,
                    transactions,
                    internalTransactions,
                    tokens,
                    erc20Tokens)
                .GetStats();

            var score = walletStats.GetScore();
            var scoringData = new ScoringData(address, address, BlockchainNetwork.Polygon, score,
                JsonSerializer.Serialize(walletStats));
            await _scoringService.SaveScoringDataToDatabaseAsync(scoringData);

            return await Result<PolygonWalletScore>.SuccessAsync(new()
            {
                Address = address,
                Stats = walletStats,
                Score = score
            }, "Got polygon wallet score.");
        }
    }
}