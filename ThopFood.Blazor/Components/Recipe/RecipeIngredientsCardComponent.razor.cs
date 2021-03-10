using System.Collections.Generic;
using ThopFood.Blazor.Enums;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Components.Recipe
{
    public partial class RecipeIngredientsCardComponent
    {
        public List<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>
        {
            new RecipeIngredient
                {Ingredient = new Ingredient {Name = "Garlic", Type = IngredientType.Amount}, Amount = 5},
            new RecipeIngredient
                {Ingredient = new Ingredient {Name = "Water", Type = IngredientType.Volume}, Amount = 1000},
            new RecipeIngredient
                {Ingredient = new Ingredient {Name = "Flour", Type = IngredientType.Weight}, Amount = 1000000},

        };

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