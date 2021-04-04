using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AstormAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "AstormAPI", Version = "v1"}); });
        }
    }
}