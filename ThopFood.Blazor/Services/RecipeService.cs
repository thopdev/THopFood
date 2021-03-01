using System.Threading.Tasks;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Services
{
    public interface IRecipeService
    {
        Task<RecipeModel> GetRecipeById(string id);
    }

    public class RecipeServiceFaker : IRecipeService
    {
        public async Task<RecipeModel> GetRecipeById(string id)
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
