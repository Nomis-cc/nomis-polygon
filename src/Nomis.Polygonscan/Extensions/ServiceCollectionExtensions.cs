using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nomis.Blockchain.Abstractions.Settings;
using Nomis.Polygonscan.Interfaces;
using Nomis.Polygonscan.Interfaces.Settings;
using Nomis.Utils.Extensions;

namespace Nomis.Polygonscan.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Polygonscan service.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddPolygonscanService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSettings<PolygonscanSettings>(configuration);
            var settings = configuration.GetSettings<ApiVisibilitySettings>();
            if (settings.PolygonAPIEnabled)
            {
                return services
                    .AddTransient<IPolygonscanClient, PolygonscanClient>()
                    .AddTransientInfrastructureService<IPolygonscanService, PolygonscanService>();
            }
            else
            {
                return services;
            }
        }
    }
}