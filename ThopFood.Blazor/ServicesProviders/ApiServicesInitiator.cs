using Microsoft.Extensions.DependencyInjection;
using ThopFood.Blazor.Services;

namespace ThopFood.Blazor.ServicesProviders
{
    public class ApiServicesInitiator : IServiceInitiator
    {
        public void InitiateService(IServiceCollection services)
        {
            services.Scan(scan => 
                scan.FromAssemblyOf<Program>()
                    .AddClasses()
                        .AsImplementedInterfaces());
        }
    }
}
