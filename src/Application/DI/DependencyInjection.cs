using Application.CQRS;
using Application.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<AppServices.IAppChainService, AppServices.AppChainService>();
            services.AddScoped<AppServices.IAppChainServiceDepreciate, AppServices.AppChainServiceDepreciate>();
            services.AddScoped<IBlockChainQueries, BlockChainQueries>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            var assembly = typeof(Application.CQRS.Commands.AddChainBlockCommand).Assembly;

            var handlerTypes = assembly.GetTypes()
        .Where(t => !t.IsAbstract && !t.IsInterface)
        .SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
        .Where(x => x.i.IsGenericType && x.i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));

            foreach (var h in handlerTypes)
            {
                services.AddScoped(h.i, h.t);
            }

            return services;
        }
    }
}
