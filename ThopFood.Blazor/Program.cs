#define Faker
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ThopFood.Blazor.Extensions;

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
            services.InitiateServices(typeof(Program).Assembly);
        }
    }
}