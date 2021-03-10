using System;
using System.Text.Json;
using System.Threading.Tasks;
using ThopFood.Blazor.Models;
using ThopFood.Shared.Dtos.Recipes;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public interface IRecipeService
    {
        Task<RecipeModel> GetRecipeById(int id);
    }

    public class RecipeHttpService : IRecipeService
    {
        private const string ControllerEndpoint = "recipe";

        private readonly IHttpService _httpService;

        public RecipeHttpService(IHttpService httpService)
        {
            _httpService = httpService;
        }


        public async Task<RecipeModel> GetRecipeById(int id)
        {
            var recipe = await _httpService.GetAsync<RecipeDto>(ControllerEndpoint, id);

            return new RecipeModel
            {
                Title = recipe.Title,
                Description = recipe.Description,
                Favorite = recipe.Favorite,
                ImageUrl = recipe.ImageUrl
            };
        }
    }

    public class RecipeServiceFaker : IRecipeService
    {
        public async Task<RecipeModel> GetRecipeById(int id)
        {
            await Task.Delay(1000);
            return new RecipeModel
            {
                Title = "Donuts and more!",
                Description = "Very nice food. It smells amazing!!!",
                ImageUrl = "https://scx1.b-cdn.net/csz/news/800a/2016/howcuttingdo.jpg"
            };
        }
    }
}
