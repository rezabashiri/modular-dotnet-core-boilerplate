




using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Identity.Core.Extensions;
using Modules.Identity.Infrastructure.Extensions;

namespace Modules.Identity.Extensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentityCore()
                .AddIdentityInfrastructure(configuration);
            return services;
        }

        public static IApplicationBuilder UseIdentityModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}