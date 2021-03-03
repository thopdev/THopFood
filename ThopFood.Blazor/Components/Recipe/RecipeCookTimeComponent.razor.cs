using Microsoft.AspNetCore.Components;

namespace ThopFood.Blazor.Components.Recipe
{
    public partial class RecipeCookTimeComponent
    {
        [Parameter]
        public int CookTime { get; set; }

        [Parameter]
        public int PrepTime { get; set; }

        public int TotalTime => CookTime = PrepTime;

    }
}
