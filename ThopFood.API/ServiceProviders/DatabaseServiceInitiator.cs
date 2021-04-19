using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThopFood.API.Data;
using ThopFood.API.Repositories;
using ThopFood.API.Repositories.Interfaces;

namespace ThopFood.API.ServiceProviders
{
    public class DatabaseServiceInitiator : IServiceInitiator
    {
        public void InitiateServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDatabaseContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeStepRepository, RecipeStepRepository>();
        }
    }
}
