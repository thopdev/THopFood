using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ThopFood.API.ServiceProviders
{
    public class CorsServiceInitiator : IServiceInitiator
    {
        public void InitiateServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "all",
                    builder =>
                    {
                        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                    });
            });
        }
    }
}
