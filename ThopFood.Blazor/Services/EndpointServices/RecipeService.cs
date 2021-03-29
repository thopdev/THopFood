using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using ThopFood.Blazor.Models;
using ThopFood.Shared.Dtos.EntityCreated;
using ThopFood.Shared.Dtos.Recipes;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public interface IRecipeService
    {
        Task<RecipeModel> GetRecipeById(int id);
        Task<int> CreateRecipeAsync(RecipeModel recipe);
        Task UpdateRecipeAsync(RecipeModel recipe);
    }

    public class RecipeHttpService : IRecipeService
    {
        private const string ControllerEndpoint = "recipe";

        private readonly IHttpService _httpService;
        private readonly IMapper _mapper;

        public RecipeHttpService(IHttpService httpService, IMapper mapper)
        {
            _httpService = httpService;
            _mapper = mapper;
        }

        public async Task<RecipeModel> GetRecipeById(int id)
        {
            var recipe = await _httpService.GetAsync<RecipeDto>(ControllerEndpoint, id);

            return new RecipeModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Favorite = recipe.Favorite,
                ImageUrl = recipe.ImageUrl,
                RecipeIngredientIds = recipe.Ingredients?.Select(x => new RecipeIngredientId
                {
                    Amount = x.Amount,
                    IngredientId = x.Id
                }).ToArray() ?? Array.Empty<RecipeIngredientId>()
            };
        }

        public async Task<int> CreateRecipeAsync(RecipeModel recipe)
        {
            var dto = _mapper.Map<NewRecipeDto>(recipe);
            var idModel = await _httpService.PostAsync<EntityCreateDto>(ControllerEndpoint, dto);
            return idModel.Id;
        }

        public async Task UpdateRecipeAsync(RecipeModel recipe)
        {
            var id = recipe.Id;
            var dto = _mapper.Map<UpdateRecipeDto>(recipe);

            await _httpService.PutAsync(ControllerEndpoint, id, dto);
        }
    }
}
