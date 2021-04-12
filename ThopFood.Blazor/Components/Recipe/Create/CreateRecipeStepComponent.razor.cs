using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThopFood.Blazor.Models.Recipe.Create;

namespace ThopFood.Blazor.Components.Recipe.Create
{
    public partial class CreateRecipeStepComponent
    {
        public List<CreateRecipeStep> RecipeSteps { get; set; } = new List<CreateRecipeStep>();

        public CreateRecipeStep NewRecipeStep { get; set; } = new CreateRecipeStep();

        [Parameter]
        public EventCallback<CreateRecipeStep> OnNewRecipe { get; set; }

        public async Task NewRecipeStepSubmit()
        {
            RecipeSteps.Add(NewRecipeStep);
            await OnNewRecipe.InvokeAsync(NewRecipeStep);
            NewRecipeStep = new CreateRecipeStep();
        }

    }
}