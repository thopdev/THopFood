#define Faker
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using ThopFood.Blazor.Services;
using ThopFood.Blazor.Services.EndpointServices;

namespace ThopFood.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            RegisterServices(builder.Services);

            await builder.Build().RunAsync();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44377/api") });
            services.AddMudServices();

            services.AddScoped<IHttpService, HttpService>();

            services.AddSingleton(new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
            services.AddScoped<IJsonService, JsonService>();

            services.AddScoped<IRecipeService, RecipeHttpService>();
            services.AddScoped<IUserProfileService, UserProfileHttpService>();
        }
    }
}