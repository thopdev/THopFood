using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Models.Recipe.Create;
using ThopFood.Blazor.Services.EndpointServices;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;

namespace ThopFood.Blazor.Pages.Recipe
{
    public partial class CreateRecipePage
    {
        public RecipeModel Recipe { get; set; }

        [Inject] public IMapper Mapper { get; set; }
        [Inject] public IRecipeService RecipeService { get; set; }
        [Inject] public IRecipeStepHttpService RecipeStepHttpService { get; set; }

        private MudTabs _tabs;
        private MudTabPanel _titleTab;
        private MudTabPanel _descriptionTab;
        private MudTabPanel _stepsTab;
        private MudTabPanel _ingredientsTab;


        private RecipeCreationStatus _status;

        public async Task OnTitleSubmit(CreateRecipeTitle newValues)
        {
            var recipe = Recipe ?? new RecipeModel();

            recipe.Title = newValues.Title;
            recipe.Description = newValues.Description;
            recipe.ImageUrl = newValues.ImageUrl;

            if (Recipe is null)
            {
                var id = await RecipeService.CreateRecipeAsync(recipe);
                Recipe = await RecipeService.GetRecipeById(id);
                _status = RecipeCreationStatus.Description;
                StateHasChanged();

                _tabs.ActivatePanel(_descriptionTab);

                return;
            }

            throw new NotImplementedException();
        }

        public async Task OnUpdate(object newValues)
        {
            var recipe = Recipe ?? new RecipeModel();

            Mapper.Map(newValues, recipe);

            UpdateTabs(newValues);

            if (Recipe is null)
            {
                var id = await RecipeService.CreateRecipeAsync(recipe);
                Recipe = await RecipeService.GetRecipeById(id);
                return;
            }

             await  RecipeService.UpdateRecipeAsync(Recipe);
        }

        public async Task OnNewRecipeStep(CreateRecipeStep step)
        {
            RecipeStepHttpService.CreateAsync(Recipe.Id, step);
            UpdateTabs(step);
        }

        public void UpdateTabs(object obj)
        {
            var newStatus = (obj) switch
            {
                CreateRecipeTitle => RecipeCreationStatus.Description,
                CreateRecipeDescription => RecipeCreationStatus.Steps,
                CreateRecipeStep => RecipeCreationStatus.Ingredient,
                _ => throw new ArgumentException($"Does not support model of type {obj.GetType().Name}")
            };

            if (newStatus <= _status) return;
            _status = newStatus;
            _tabs.Panels[(int)newStatus].Disabled = false;
            StateHasChanged();
            _tabs.ActivatePanel(_tabs.ActivePanelIndex + 1);
            StateHasChanged();


        }
    }

    public enum RecipeCreationStatus
    {
        Title,
        Description,
        Steps,
        Ingredient,
        Utensil
    }
}