using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.TokenCacheProviders.InMemory;
using Newtonsoft.Json;
using TemplateBFF.DependencyInjection;
using TemplateBFF.DependencyInjection.Swagger;
using TemplateBFF.Adapter;
using TemplateBFF.WebApi;
using TemplateBFF.WebApi.Extensions;

namespace TemplateBFF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCompression();
            services.AddControllers().AddControllersAsServices().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddAutoMapper(
                typeof(WebApiMapperProfile),
                typeof(AdapterMapperProfile));

            services
                .AddBusinessExceptionFilter()
                .AddNotFoundExceptionFilter()
                .AddVersioning()
                .AddSwagger()
                .AddProtectedWebApi(Configuration)
                .AddProtectedWebApiCallsProtectedWebApi(Configuration)
                .AddInMemoryTokenCaches();

            ConfigureAppInsights(services);

            services
                .AddApplication()
                .AddAdapter(Configuration.SafeGet<AdapterConfiguration>());
        }

        private static void ConfigureAppInsights(IServiceCollection services)
        {
            Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions aiOptions
                            = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions
                            {
                                EnableAdaptiveSampling = false,
                                EnableQuickPulseMetricStream = false,
                                EnableHeartbeat = false,
                                EnablePerformanceCounterCollectionModule = false,
                                EnableEventCounterCollectionModule = false,
                                EnableAuthenticationTrackingJavaScript = false
                            };

            // The following line enables Application Insights telemetry collection.
            services.AddApplicationInsightsTelemetry(aiOptions);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseVersionedSwagger(provider);
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}