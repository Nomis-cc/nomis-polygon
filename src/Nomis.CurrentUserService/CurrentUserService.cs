using Microsoft.AspNetCore.Http;
using Nomis.CurrentUserService.Interfaces;
using Nomis.Utils.Contracts.Services;

namespace Nomis.CurrentUserService
{
    /// <inheritdoc cref="ICurrentUserService"/>
    internal sealed class CurrentUserService : 
        ICurrentUserService,
        IScopedService
    {
        private readonly IHttpContextAccessor _accessor;

        /// <summary>
        /// Initialize <see cref="CurrentUserService"/>.
        /// </summary>
        /// <param name="accessor"><see cref="IHttpContextAccessor"/>.</param>
        public CurrentUserService(
            IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <inheritdoc/>
        public Guid GetUserId()
        {
            return Guid.Empty; // TODO - implement getting id from user wallet
        }

        /// <inheritdoc/>
        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }
    }
}