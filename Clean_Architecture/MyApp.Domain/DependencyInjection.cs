using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.Options;

namespace MyApp.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration
                .GetSection(ConnectionStringOptions.SectionName));
            return services;
        }


    }
}
