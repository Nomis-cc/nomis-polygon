using Nomis.Domain.Abstractions;
using Nomis.Domain.Contracts;
using Nomis.Domain.Scoring.Events;
using Nomis.Utils.Enums;

namespace Nomis.Domain.Scoring.Entities
{
    /// <summary>
    /// Scoring data.
    /// </summary>
    public class ScoringData :
        AuditableAggregate,
        IVersionableByEvent<Guid, ScoringData, ScoringDataAddedEvent>,
        IVersionableByEvent<Guid, ScoringData, ScoringDataUpdatedEvent>,
        IVersionableByEvent<Guid, ScoringData, ScoringDataRemovedEvent>
    {
        /// <summary>
        /// Initialize <see cref="ScoringData"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized with the new <see cref="Guid"/> value.
        /// </remarks>
        public ScoringData()
        {
            RequestAddress = string.Empty;
            Blockchain = BlockchainNetwork.None;
            StatData = string.Empty;
        }

        /// <summary>
        /// Initialize <see cref="ScoringData"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized with the new <see cref="Guid"/> value.
        /// </remarks>
        /// <param name="requestAddress">Request address.</param>
        /// <param name="resolvedAddress">Resolved request address.</param>
        /// <param name="blockchain">Blockchain.</param>
        /// <param name="score">Score.</param>
        /// <param name="statData">Scoring stat data.</param>
        public ScoringData(
            string requestAddress,
            string resolvedAddress,
            BlockchainNetwork blockchain,
            double score,
            string statData)
        {
            RequestAddress = requestAddress;
            ResolvedAddress = resolvedAddress;
            Blockchain = blockchain;
            Score = score;
            StatData = statData;
        }

        /// <summary>
        /// Request address.
        /// </summary>
        public string RequestAddress { get; private set; }

        /// <summary>
        /// Resolved request address.
        /// </summary>
        public string? ResolvedAddress { get; private set; }

        /// <summary>
        /// Blockchain.
        /// </summary>
        public BlockchainNetwork Blockchain { get; private set; }

        /// <summary>
        /// Score.
        /// </summary>
        public double Score { get; private set; }

        /// <summary>
        /// Scoring stat data.
        /// </summary>
        public string StatData { get; private set; }

        #region IVersionableByEvent

        /// <inheritdoc/>
        public void When(ScoringDataAddedEvent @event)
        {
            RequestAddress = @event.RequestAddress;
            ResolvedAddress = @event.ResolvedAddress;
            Blockchain = @event.Blockchain;
            Score = @event.Score;
            StatData = @event.StatData;
            IncrementVersion();
        }

        /// <inheritdoc/>
        public void When(ScoringDataUpdatedEvent @event)
        {
            RequestAddress = @event.RequestAddress;
            ResolvedAddress = @event.ResolvedAddress;
            Blockchain = @event.Blockchain;
            Score = @event.Score;
            StatData = @event.StatData;
            IncrementVersion();
        }

        /// <inheritdoc/>
        public void When(ScoringDataRemovedEvent @event)
        {
            IncrementVersion();
        }

        #endregion IVersionableByEvent

        /// <inheritdoc/>
        protected override void Apply(IDomainEvent @event)
        {
            When((dynamic)@event);
        }
    }
}