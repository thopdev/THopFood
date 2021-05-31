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


        public List<RecipeUtensil> Utensils { get; set; } = new List<RecipeUtensil>(new List<RecipeUtensil>
        {
            new RecipeUtensil {Name = "AirFryer"},
            new RecipeUtensil {Name = "Spoon"},
            new RecipeUtensil{Name = "Saute Pan"},
            new RecipeUtensil{Name = "BBQ"},
            new RecipeUtensil{Name = "Dutch Oven"}
        });
    }
}