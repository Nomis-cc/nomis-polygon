using Nomis.Utils.Contracts.Common;
using Nomis.Utils.Contracts.Deleting;

namespace Nomis.Domain.Settings
{
    /// <summary>
    /// Entity settings.
    /// </summary>
    public class EntitySettings :
        ISettings
    {
        /// <summary>
        /// "soft delete" is enabled.
        /// </summary>
        /// <remarks>
        /// Using for <see cref="ISoftDelete"/>.
        /// </remarks>
        public bool SoftDeleteEnabled { get; set; } = true;
    }
}