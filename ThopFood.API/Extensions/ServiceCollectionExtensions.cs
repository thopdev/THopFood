using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThopFood.API.ServiceProviders;

namespace ThopFood.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void InitiateServices(this IServiceCollection serviceCollection, IConfiguration configuration, params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(assembly =>
                assembly.GetTypes().Where(x =>
                    typeof(IServiceInitiator).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract));

            foreach (var type in types)
            {
                var initiator = (IServiceInitiator)Activator.CreateInstance(type);
                initiator.InitiateServices(serviceCollection, configuration);
            }
        }

    }
}
