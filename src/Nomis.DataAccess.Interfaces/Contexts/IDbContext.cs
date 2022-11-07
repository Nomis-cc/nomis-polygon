using System.Data;

using Nomis.DataAccess.Interfaces.Contracts;

namespace Nomis.DataAccess.Interfaces.Contexts
{
    /// <summary>
    /// Data access database context.
    /// </summary>
    public interface IDbContext :
        ISupportsSavingChanges
    {
        /// <summary>
        /// The database connection for the current data access database context.
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// Are there any changes in the data access database context.
        /// </summary>
        bool HasChanges { get; }
    }
}
