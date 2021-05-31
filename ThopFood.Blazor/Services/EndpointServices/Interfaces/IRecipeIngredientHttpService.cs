using System.Threading.Tasks;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task CreateAsync(int recipeId, RecipeIngredient recipeIngredient);
    }
}