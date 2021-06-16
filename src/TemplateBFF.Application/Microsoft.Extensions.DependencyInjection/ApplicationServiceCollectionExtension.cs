using TemplateBFF.Application.Services.Users;
using TemplateBFF.Domain.Services;
using System.Diagnostics.CodeAnalysis;

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
