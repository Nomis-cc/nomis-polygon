using Nomis.Domain.Scoring.Entities;
using Nomis.Utils.Contracts.Services;

namespace Nomis.ScoringService.Interfaces
{
    /// <summary>
    /// Scoring service.
    /// </summary>
    public interface IScoringService :
        IApplicationService
    {
        /// <summary>
        /// Save scoring data to database.
        /// </summary>
        /// <param name="scoringData">Wallet scoring data.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        public Task SaveScoringDataToDatabaseAsync(
            ScoringData scoringData,
            CancellationToken cancellationToken = default);
    }
}