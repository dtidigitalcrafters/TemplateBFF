using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace TemplateBFF.DependencyInjection
{
    public static class CompressionResponseExtension
    {
        public static void ConfigureCompression(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new string[]{
                    "text/html",
                    "text/css",
                    "application/javascript",
                    "text/javascript",
                    "application/json"
                };
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
        }
    }
}
