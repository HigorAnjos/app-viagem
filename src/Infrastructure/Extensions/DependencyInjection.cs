using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services.AddServices();

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IService, Service>();

            return services;
        }
    }
}
