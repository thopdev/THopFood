using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Models.Recipe.Create;
using ThopFood.Blazor.Services.EndpointServices;

namespace ThopFood.Blazor.Pages.Recipe
{
    public partial class CreateRecipePage
    {
        public RecipeModel Recipe { get; set; }

        [Inject] public IRecipeService RecipeService { get; set; }

        public async Task OnTitleSubmit(CreateRecipeTitle newValues)
        {
            var recipe = Recipe ?? new RecipeModel();

            recipe.Title = newValues.Title;
            recipe.Description = newValues.Description;
            recipe.ImageUrl = newValues.ImageUrl;

            if (Recipe is null)
            {
                var id = await RecipeService.CreateRecipeAsync(recipe);
                Recipe = await RecipeService.GetRecipeById(id);
                return;
            }

            throw new NotImplementedException();
        }
    }
}