using Domain.Abstractions;
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

            Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);
            services.AddMemoryCache()
                .AddScoped<IScriptLoader, ScriptLoader>();

            return services;
        }
    }
}
