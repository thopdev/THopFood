using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ThopFood.API.ServiceProviders
{
    public interface IServiceInitiator
    {
        public void InitiateServices(IServiceCollection services, IConfiguration configuration);
    }
}
