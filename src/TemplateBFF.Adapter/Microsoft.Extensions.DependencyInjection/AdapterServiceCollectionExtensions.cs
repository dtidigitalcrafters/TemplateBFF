using TemplateBFF.Domain.Adapters;
using TemplateBFF.DtiRoundAdapter;
using TemplateBFF.DtiRoundAdapter.Adapters.Users;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AdapterServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddDtiRoundAdapter(this IServiceCollection services,
            AdapterConfiguration configuration)
        {

            services.AddHttpClient(Constants.RoundHttpClientName, c =>
            {
                c.BaseAddress = new Uri(configuration.Url);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddScoped<IUserAdapter, UserAdapter>();

            return services;
        }

    }
}
