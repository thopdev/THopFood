using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models.Recipe.Create;

namespace ThopFood.Blazor.Components.Recipe.Create
{
    public partial class CreateRecipeTitleComponent
    {
        private readonly CreateRecipeTitle _model = new();


        [Parameter]
        public EventCallback<CreateRecipeTitle> OnSubmit { get; set; }
    }
}