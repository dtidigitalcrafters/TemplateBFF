using System.Diagnostics.CodeAnalysis;
using TemplateBFF.Application.Services.Users;
using TemplateBFF.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtension
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IListUsersService, ListUsersService>();

            return services;
        }
    }
}
