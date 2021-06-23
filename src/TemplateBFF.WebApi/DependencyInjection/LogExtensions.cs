using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace TemplateBFF.WebApi.DependencyInjection
{
    public static class LogExtensions
    {
        public static IServiceCollection ConfigureLogs(this IServiceCollection services)
        {
            ApplicationInsightsServiceOptions options = new ApplicationInsightsServiceOptions
            {
                EnableDebugLogger = false
            };

            services.AddApplicationInsightsTelemetry(options);

            return services;
        }
    }
}
