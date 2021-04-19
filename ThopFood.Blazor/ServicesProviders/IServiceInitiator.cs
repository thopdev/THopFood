using Microsoft.Extensions.DependencyInjection;

namespace ThopFood.Blazor.ServicesProviders
{
    public interface IServiceInitiator
    {
        public void InitiateService(IServiceCollection serviceCollection);
    }
}
