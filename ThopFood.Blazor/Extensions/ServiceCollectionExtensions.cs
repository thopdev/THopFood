using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ThopFood.Blazor.ServicesProviders;

namespace ThopFood.Blazor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void InitiateServices(this IServiceCollection serviceCollection, params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(assembly =>
                assembly.GetTypes().Where(x =>
                        typeof(IServiceInitiator).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract));

            foreach (var type in types)
            {
                var initiator = (IServiceInitiator) Activator.CreateInstance(type);
                initiator.InitiateService(serviceCollection);
            }
        }
    }
}
