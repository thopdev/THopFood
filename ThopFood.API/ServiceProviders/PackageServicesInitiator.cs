using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ThopFood.API.ServiceProviders
{
    public class PackageServicesInitiator : IServiceInitiator
    {
        public void InitiateServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ThopFood.API", Version = "v1" });
                
            });
            
            services.AddAutoMapper(typeof(Program).Assembly);
        }
    }
}
