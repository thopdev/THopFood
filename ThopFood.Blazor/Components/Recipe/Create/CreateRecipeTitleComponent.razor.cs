using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Models.Recipe.Create;

namespace ThopFood.Blazor.Components.Recipe.Create
{
    public partial class CreateRecipeTitleComponent
    {
        private CreateRecipeTitle _model;

        [CascadingParameter] 
        public RecipeModel Recipe { get; set; }

        [Parameter]
        public EventCallback<CreateRecipeTitle> OnSubmit { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _model = new CreateRecipeTitle();

            if (Recipe is not null)
            {
                _model.Title = Recipe.Title;
                _model.Description = Recipe.Description;
                _model.ImageUrl = Recipe.ImageUrl;
                return;
            }
        }
    }
}