using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
