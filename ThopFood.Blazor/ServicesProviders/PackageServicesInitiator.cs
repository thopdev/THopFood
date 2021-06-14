using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace ThopFood.Blazor.ServicesProviders
{
    public class PackageServicesInitiator : IServiceInitiator
    {
        public void InitiateService(IServiceCollection services)
        {
            services.AddMudServices();
            services.AddAutoMapper(typeof(Program).Assembly);
        }
    }
}
