using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices;

namespace ThopFood.Blazor.Pages
{
    public partial class Index
    {
        [Inject] public IRecipeService RecipeService { get; set; }

        private RecipeModel _recipe;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _recipe = await RecipeService.GetRecipeById(3);
        }
    }
}
