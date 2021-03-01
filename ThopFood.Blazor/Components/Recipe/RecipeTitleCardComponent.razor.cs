using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Components.Recipe
{
    public partial class RecipeTitleCardComponent
    {
        [Parameter] public RecipeModel Recipe { get; set; }

        [Parameter] public EventCallback OnRecipeChange { get; set; }

        public bool Loaded => Recipe != null;

        public async Task FavoriteClick()
        {
            Recipe.Favorite = !Recipe.Favorite;
            await OnRecipeChange.InvokeAsync();
        }
    }
}
