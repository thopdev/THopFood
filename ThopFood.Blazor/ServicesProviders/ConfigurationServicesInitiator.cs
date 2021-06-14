using System;
using System.Net.Http;
using System.Text.Json;
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
