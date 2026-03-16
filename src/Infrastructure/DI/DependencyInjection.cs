using Domain.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<Domain.Repositories.IUnitOfWork, DB.UnitOfWork>();
            services.AddScoped<IChainProvider, Providers.BlockChainProvider>();
            services.AddScoped<IProviderFactory, Providers.SourceProviderFactory>();
            return services;
        }
    }
}
