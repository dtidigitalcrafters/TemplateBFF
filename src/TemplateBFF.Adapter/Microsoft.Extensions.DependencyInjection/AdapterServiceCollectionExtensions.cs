using System;
using System.Diagnostics.CodeAnalysis;
using TemplateBFF.Adapter;
using TemplateBFF.Adapter.Adapters.Users;
using TemplateBFF.Domain.Adapters;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AdapterServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddAdapter(this IServiceCollection services,
            AdapterConfiguration configuration)
        {

            services.AddHttpClient(Constants.AdapterClientName, c =>
             {
                 c.BaseAddress = new Uri(configuration.Url);
                 c.DefaultRequestHeaders.Add("Accept", "application/json");
             });

            services.AddScoped<IUserAdapter, UserAdapter>();

            return services;
        }

    }
}
