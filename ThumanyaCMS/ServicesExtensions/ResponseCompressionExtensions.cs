using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace ThumanyaCMS.ServicesExtensions
{
    public static class ResponseCompressionExtensions
    {
        public static IServiceCollection AddCompressionMiddleware(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
                // options.Providers.Add<BrotliCompressionProvider>();

                // Add specific MIME types
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] {
            "application/json",
            "text/json",
            //"text/plain",
            //"text/html",
            //"text/css",
            //"application/javascript",
            //"image/svg+xml"
                    });
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal; // Or Optimal for better compression
            });

            return services;
        }
    }
}
