using AutoMapper;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Models.Recipe.Create;
using ThopFood.Shared.Dtos.Recipes;
using ThopFood.Shared.Requests.RecipeStep;

namespace ThopFood.Blazor.AutoMappers
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<CreateRecipeTitle, RecipeModel>();
            CreateMap<CreateRecipeDescription, RecipeModel>();
            CreateMap<RecipeModel, UpdateRecipeDto>();
            CreateMap<RecipeModel, NewRecipeDto>();

            CreateMap<CreateRecipeStep, CreateRecipeStepRequest>();

        }
    }
}
