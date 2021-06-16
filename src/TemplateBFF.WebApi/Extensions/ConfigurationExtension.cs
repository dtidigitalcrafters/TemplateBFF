using Microsoft.Extensions.Configuration;
using System.Linq;

namespace TemplateBFF.WebApi.Extensions
{
    public static class ConfigurationExtension
    {
        public static T SafeGet<T>(this IConfiguration configuration)
        {
            var typeName = typeof(T).Name;

            if (configuration.GetChildren().Any(item => item.Key == typeName))
            {
                return configuration.GetSection(typeName).Get<T>();
            }
            return default;
        }
    }

}
