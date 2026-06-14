using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Options;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repository;


namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseNpgsql(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>()
                    .Value.DefaultConnection);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}






