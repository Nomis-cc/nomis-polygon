using System.Numerics;
using System.Text.Json.Serialization;

using Nomis.Blockchain.Abstractions.Models;
using Nomis.Polygonscan.Interfaces.Extensions;

namespace Nomis.Polygonscan.Interfaces.Models
{
    /// <inheritdoc cref="ITransactionIntervalData"/>
    public class PolygonTransactionIntervalData :
        ITransactionIntervalData
    {
        /// <inheritdoc />
        public DateTime StartDate { get; set; }

        /// <inheritdoc />
        public DateTime EndDate { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public BigInteger AmountSum { get; set; }

        /// <inheritdoc cref="ITransactionIntervalData.AmountSum"/>
        public decimal AmountSumValue => AmountSum.ToMatic();

        /// <inheritdoc />
        [JsonIgnore]
        public BigInteger AmountOutSum { get; set; }

        /// <inheritdoc cref="ITransactionIntervalData.AmountOutSum"/>
        public decimal AmountOutSumValue => AmountOutSum.ToMatic();

        /// <inheritdoc />
        [JsonIgnore]
        public BigInteger AmountInSum { get; set; }

        /// <inheritdoc cref="ITransactionIntervalData.AmountInSum"/>
        public decimal AmountInSumValue => AmountInSum.ToMatic();

        /// <inheritdoc />
        public int Count { get; set; }
    }
}