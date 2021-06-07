using System.Threading.Tasks;
using AutoMapper;
using ThopFood.Blazor.Models.Recipe.Create;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;
using ThopFood.Shared.Dtos.Recipes;
using ThopFood.Shared.Requests.RecipeStep;
using ThopFood.Shared.Responses.EntityCreated;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public class RecipeStepHttpService : IRecipeStepHttpService
    {
        private const string recipe = "recipe";
        private const string step = "step";
        
        private readonly IHttpService _httpService;
        private readonly IMapper _mapper;

        public RecipeStepHttpService(IHttpService httpService, IMapper mapper)
        {
            _httpService = httpService;
            _mapper = mapper;
        }

        public async Task CreateAsync(int recipeId, CreateRecipeStep stepModel)
        {
            var request = _mapper.Map<CreateRecipeStepRequest>(stepModel);

            await _httpService.PostAsync<EntityCreateResponse>($"{recipe}/{recipeId}/{step}", request);
        }
    }
}
