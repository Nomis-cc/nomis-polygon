using Microsoft.Extensions.DependencyInjection;
using Nomis.ScoringService.Interfaces;
using Nomis.Utils.Extensions;

namespace Nomis.ScoringService.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add a service for working with scoring.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddScoringService(this IServiceCollection services)
        {
            return services
                .AddScopedApplicationService<IScoringService, ScoringService>();
        }
    }
}