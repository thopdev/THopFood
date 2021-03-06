using System;
using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models.Recipe.Create;

namespace ThopFood.Blazor.Components.Recipe.Create
{
    public partial class CreateRecipeDescriptionComponent
    {
        private CreateRecipeDescription _model;

        [Parameter]
        public EventCallback<CreateRecipeDescription> OnSubmit { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _model = new CreateRecipeDescription();
        }
    }
}