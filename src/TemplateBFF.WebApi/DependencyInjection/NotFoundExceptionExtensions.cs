using Microsoft.Extensions.DependencyInjection;
using TemplateBFF.Filters;

namespace TemplateBFF.DependencyInjection
{
    public static class NotFoundExceptionExtensions
    {
        public static IServiceCollection AddNotFoundExceptionFilter(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(NotFoundExceptionFilter));
            });

            return services;
        }
    }
}