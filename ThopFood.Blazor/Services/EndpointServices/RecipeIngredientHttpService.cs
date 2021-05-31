using System.Threading.Tasks;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;
using ThopFood.Shared.Requests.RecipeIngredient;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public class RecipeIngredientHttpService : IRecipeIngredientService
    {
        private const string Recipe = "recipe";
        private const string Ingredient = "ingredient";

        private readonly IHttpService _httpService;

        public RecipeIngredientHttpService(IHttpService httpService)
        {
            _httpService = httpService;
        }


        public async Task CreateAsync(int recipeId, RecipeIngredient recipeIngredient)
        {
            var newRecipeIngredient = new AddOrUpdateRecipeIngredientRequest
            {
                Amount = recipeIngredient.Amount
            };

            await _httpService.PutAsync($"{Recipe}/{recipeId}/{Ingredient}", recipeIngredient.Ingredient.Id, newRecipeIngredient);
        }
    }
}
