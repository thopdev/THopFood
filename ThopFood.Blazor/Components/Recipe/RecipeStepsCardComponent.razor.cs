using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Components.Recipe
{
    public partial class RecipeStepsCardComponent
    {
        [Parameter]
        public List<RecipeStepModel> Steps { get; set; }
    }
}