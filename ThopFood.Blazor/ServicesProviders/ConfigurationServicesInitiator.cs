using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ThopFood.Blazor.ServicesProviders
{
    public class ConfigurationServicesInitiator : IServiceInitiator
    {
        public void InitiateService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5004/api") });

            serviceCollection.AddSingleton(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
