using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;

namespace ThopFood.Blazor.Components.Recipe
{
    public partial class RecipeIngredientsCardComponent
    {
        [Parameter]
        public RecipeIngredientId[] IngredientIds { get; set; }

        public RecipeIngredient[] Ingredients { get; set; }

        [Inject] public IIngredientService IngredientService { get; set; }

        protected override async Task OnInitializedAsync()
        {

            if (IngredientIds == null)
            {
                throw new ArgumentNullException($"Ingredient list cannot be null in {nameof(RecipeIngredientsCardComponent)}");
            }

            var ingredientTasks = IngredientIds.Select(GetIngredientWithAmount);

            Ingredients = await Task.WhenAll(ingredientTasks);

            await base.OnInitializedAsync();
        }

        public async Task<RecipeIngredient> GetIngredientWithAmount(RecipeIngredientId recipeIngredient)
        {
            var ingredient = await IngredientService.GetIngredientById(recipeIngredient.IngredientId);
            return new RecipeIngredient
            {
                Ingredient = ingredient,
                Amount = recipeIngredient.Amount
            };
        }


        public List<Utensil> Utensils { get; set; } = new List<Utensil>(new List<Utensil>
        {
            new Utensil {Name = "AirFryer"},
            new Utensil {Name = "Spoon"},
            new Utensil{Name = "Saute Pan"},
            new Utensil{Name = "BBQ"},
            new Utensil{Name = "Dutch Oven"}
        });
    }
}