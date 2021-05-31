using System.Threading.Tasks;
using ThopFood.Blazor.Models.Recipe.Create;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public interface IRecipeStepHttpService
    {
        Task CreateAsync(int recipeId, CreateRecipeStep stepModel);
    }
}