using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;

namespace ThopFood.Blazor.Components.Recipe.Create
{
    public partial class CreateRecipeIngredientComponent
    {
        [Inject] public IIngredientService IngredientService { get; set; }

        [Parameter]
        public EventCallback<RecipeIngredient> OnAddRecipe { get; set; }

        [Parameter]
        public EventCallback<RecipeIngredient> OnAddAndNextRecipe { get; set; }

        public Ingredient Ingredient { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }

        public MudAutocomplete<Ingredient> AutoComplete { get; set; }

        private List<Ingredient> _ingredients;

        private int NewNumber { get; set; }

        public string SearchString { get; set; }
        protected override async Task OnInitializedAsync()
        {
            RecipeIngredients = new List<RecipeIngredient>();

            await  base.OnInitializedAsync();
            _ingredients = await IngredientService.GetAllAsync();
            Console.WriteLine(JsonSerializer.Serialize(_ingredients));
        }

        private Task<IEnumerable<Ingredient>> Search(string value)
        {
            return Task.FromResult(string.IsNullOrEmpty(value) ? 
                _ingredients.Where(x => x.Name is not null) : 
                _ingredients.Where(x => x.Name is not null && x.Name.Contains(value, StringComparison.CurrentCultureIgnoreCase)));
        }

        private async Task Add() 
        {
            await OnAddRecipe.InvokeAsync(GetIngredientAndReset());
        }

        private async Task AddNext()
        {
            await OnAddAndNextRecipe.InvokeAsync(GetIngredientAndReset());

        }

        private RecipeIngredient GetIngredientAndReset()
        {
            var recipeIngredients = new RecipeIngredient
            {
                Amount = NewNumber,
                Ingredient = Ingredient
            };

            RecipeIngredients.Add(recipeIngredients);

            NewNumber = default;
            AutoComplete.Reset();
            return recipeIngredients;
        }
    }
}
