using ThopFood.Blazor.Models.Recipe.Create;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public interface IRecipeStepHttpService
    {
        void CreateAsync(int recipeId, CreateRecipeStep stepModel);
    }
}