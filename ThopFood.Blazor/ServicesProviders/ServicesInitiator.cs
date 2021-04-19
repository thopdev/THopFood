using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ThopFood.Blazor.Services;

namespace ThopFood.Blazor.ServicesProviders
{
    public class ServicesInitiator : IServiceInitiator
    {
        public void InitiateService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJsonService, JsonService>();
        }
    }
}
