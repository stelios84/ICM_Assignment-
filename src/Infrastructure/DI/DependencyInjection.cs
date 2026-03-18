using Domain.Providers;
using Infrastructure.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<Domain.Repositories.IChainRepository, Infrastructure.Repositories.ChainRepository>();
            services.AddScoped<Domain.Repositories.IUnitOfWork, DB.UnitOfWork>();


            services.AddScoped<IsourceProviderFactory, SourceProviderFactory>(x =>
            {
                return new Providers.SourceProviderFactory(new HttpClient());
            });
            return services;
        }
    }
}
