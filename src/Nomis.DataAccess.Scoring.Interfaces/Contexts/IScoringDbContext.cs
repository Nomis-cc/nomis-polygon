using Microsoft.EntityFrameworkCore;
using Nomis.DataAccess.Interfaces.Contexts;
using Nomis.Domain;
using Nomis.Domain.Scoring.Entities;

namespace Nomis.DataAccess.Scoring.Interfaces.Contexts
{
    /// <summary>
    /// The database context for accessing scoring-related data.
    /// </summary>
    public interface IScoringDbContext :
        IAuditableDbContext,
        IDbContextInterface
    {
        /// <summary>
        /// Collection with scoring data.
        /// </summary>
        public DbSet<ScoringData> ScoringDatas { get; set; }
    }
}