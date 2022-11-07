using Microsoft.Extensions.DependencyInjection;
using Nomis.CurrentUserService.Interfaces;
using Nomis.Utils.Extensions;

namespace Nomis.CurrentUserService.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add a service for working with the current user.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCurrentUserService(this IServiceCollection services)
        {
            return services
                .AddScopedInfrastructureService<ICurrentUserService, CurrentUserService>();
        }
    }
}