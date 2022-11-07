using Microsoft.AspNetCore.Http;
using Nomis.Utils.Contracts.Services;

namespace Nomis.CurrentUserService.Interfaces
{
    /// <summary>
    /// Service for working with the current user.
    /// </summary>
    public interface ICurrentUserService :
        IInfrastructureService
    {
        /// <summary>
        /// Get the user identifier.
        /// </summary>
        /// <returns>Returns the user identifier.</returns>
        public Guid GetUserId();

        /// <summary>
        /// Get the <see cref="HttpContext"/>.
        /// </summary>
        /// <returns>Returns <see cref="HttpContext"/>.</returns>
        public HttpContext GetHttpContext();
    }
}