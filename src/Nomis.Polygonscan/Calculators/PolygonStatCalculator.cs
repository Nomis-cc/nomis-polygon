using System.Numerics;

using Nomis.Blockchain.Abstractions.Calculators;
using Nomis.Blockchain.Abstractions.Models;
using Nomis.Polygonscan.Interfaces.Extensions;
using Nomis.Polygonscan.Interfaces.Models;
using Nomis.Utils.Extensions;

namespace Nomis.Polygonscan.Calculators
{
    /// <summary>
    /// Polygon wallet stats calculator.
    /// </summary>
    internal sealed class PolygonStatCalculator :
        IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>
    {
        private readonly string _address;
        private readonly decimal _balance;
        private readonly decimal _usdBalance;
        private readonly IEnumerable<PolygonscanAccountNormalTransaction> _transactions;
        private readonly IEnumerable<PolygonscanAccountInternalTransaction> _internalTransactions;
        private readonly IEnumerable<IPolygonscanAccountNftTokenEvent> _tokenTransfers;
        private readonly IEnumerable<PolygonscanAccountERC20TokenEvent> _ecr20TokenTransfers;

        public PolygonStatCalculator(
            string address,
            decimal balance,
            decimal usdBalance,
            IEnumerable<PolygonscanAccountNormalTransaction> transactions,
            IEnumerable<PolygonscanAccountInternalTransaction> internalTransactions,
            IEnumerable<IPolygonscanAccountNftTokenEvent> tokenTransfers,
            IEnumerable<PolygonscanAccountERC20TokenEvent> ecr20TokenTransfers)
        {
            _address = address;
            _balance = balance;
            _usdBalance = usdBalance;
            _transactions = transactions;
            _internalTransactions = internalTransactions;
            _tokenTransfers = tokenTransfers;
            _ecr20TokenTransfers = ecr20TokenTransfers;
        }

        public PolygonWalletStats GetStats()
        {
            if (!_transactions.Any())
            {
                return new()
                {
                    NoData = true
                };
            }

            var intervals = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>
                .GetTransactionsIntervals(_transactions.Select(x => x.TimeStamp!.ToDateTime())).ToList();
            if (!intervals.Any())
            {
                return new()
                {
                    NoData = true
                };
            }

            var monthAgo = DateTime.Now.AddMonths(-1);
            var yearAgo = DateTime.Now.AddYears(-1);

            var soldTokens = _tokenTransfers.Where(x => x.From?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true).ToList();
            var soldSum = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>
                .GetTokensSum(soldTokens.Select(x => x.Hash!), _internalTransactions.Select(x => (x.Hash!, ulong.TryParse(x.Value, out var amount) ? amount : new BigInteger(0))));

            var soldTokensIds = soldTokens.Select(x => x.GetTokenUid());
            var buyTokens = _tokenTransfers.Where(x => x.To?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true && soldTokensIds.Contains(x.GetTokenUid()));
            var buySum = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>
                .GetTokensSum(buyTokens.Select(x => x.Hash!), _internalTransactions.Select(x => (x.Hash!, ulong.TryParse(x.Value, out var amount) ? amount : new BigInteger(0))));

            var buyNotSoldTokens = _tokenTransfers.Where(x => x.To?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true && !soldTokensIds.Contains(x.GetTokenUid()));
            var buyNotSoldSum = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>
                .GetTokensSum(buyNotSoldTokens.Select(x => x.Hash!), _internalTransactions.Select(x => (x.Hash!, ulong.TryParse(x.Value, out var amount) ? amount : new BigInteger(0))));

            var holdingTokens = _tokenTransfers.Count() - soldTokens.Count;
            var nftWorth = buySum == 0 ? 0 : (decimal)soldSum / (decimal)buySum * (decimal)buyNotSoldSum;
            var contractsCreated = _transactions.Count(x => !string.IsNullOrWhiteSpace(x.ContractAddress));
            var totalTokens = _ecr20TokenTransfers.Select(x => x.TokenSymbol).Distinct();

            var turnoverIntervalsDataList =
                _transactions.Select(x => new TurnoverIntervalsData(
                    x.TimeStamp!.ToDateTime(), 
                    BigInteger.TryParse(x.Value, out var value) ? value : 0, 
                    x.From?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true));
            var turnoverIntervals = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>
                .GetTurnoverIntervals(turnoverIntervalsDataList, _transactions.Min(x => x.TimeStamp!.ToDateTime())).ToList();

            return new()
            {
                Balance = _balance.ToMatic(),
                BalanceUSD = _usdBalance,
                WalletAge = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>
                    .GetWalletAge(_transactions.Select(x => x.TimeStamp!.ToDateTime())),
                TotalTransactions = _transactions.Count(),
                TotalRejectedTransactions = _transactions.Count(t => t.IsError == "1"),
                MinTransactionTime = intervals.Min(),
                MaxTransactionTime = intervals.Max(),
                AverageTransactionTime = intervals.Average(),
                WalletTurnover = _transactions.Sum(x => decimal.TryParse(x.Value, out var value) ? value : 0).ToMatic(),
                TurnoverIntervals = turnoverIntervals,
                BalanceChangeInLastMonth = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>.GetBalanceChangeInLastMonth(turnoverIntervals),
                BalanceChangeInLastYear = IStatCalculator<PolygonWalletStats, PolygonTransactionIntervalData>.GetBalanceChangeInLastYear(turnoverIntervals),
                LastMonthTransactions = _transactions.Count(x => x.TimeStamp!.ToDateTime() > monthAgo),
                LastYearTransactions = _transactions.Count(x => x.TimeStamp!.ToDateTime() > yearAgo),
                TimeFromLastTransaction = (int)((DateTime.UtcNow - _transactions.OrderBy(x => x.TimeStamp).Last().TimeStamp!.ToDateTime()).TotalDays / 30),
                NftHolding = holdingTokens,
                NftTrading = (soldSum - buySum).ToMatic(),
                NftWorth = nftWorth.ToMatic(),
                DeployedContracts = contractsCreated,
                TokensHolding = totalTokens.Count()
            };
        }
    }
}