using Microsoft.Extensions.DependencyInjection;
using ThopFood.Blazor.Services;
using ThopFood.Blazor.Services.EndpointServices;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;

namespace ThopFood.Blazor.ServicesProviders
{
    public class ApiServicesInitiator : IServiceInitiator
    {
        public void InitiateService(IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<IRecipeService, RecipeHttpService>();
            services.AddScoped<IUserProfileService, UserProfileHttpService>();
            services.AddScoped<IIngredientService, IngredientHttpService>();
            services.AddScoped<IRecipeStepHttpService, RecipeStepHttpService>();
        }
    }
}
