using Microsoft.EntityFrameworkCore;
using Nomis.Domain.Entities;

namespace Nomis.DataAccess.Interfaces.Contexts
{
    /// <summary>
    /// Database context of access to logged data.
    /// </summary>
    public interface ILoggableDbContext :
        IDbContext
    {
        /// <summary>
        /// Collection of domain event logs.
        /// </summary>
        public DbSet<EventLog> EventLogs { get; set; }
    }
}