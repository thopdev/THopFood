using System.Threading.Tasks;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;
using ThopFood.Shared.Dtos.Ingredients;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public class IngredientHttpService : IIngredientService
    {
        private readonly IHttpService _httpService;
        private const string EndPoint = "Ingredient";

        public IngredientHttpService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            var result = await _httpService.GetAsync<IngredientDto>(EndPoint, id);

            return new Ingredient
            {
                Id = id,
                Name = result.Name,
                Type = result.Type
            };
        }
    }
}
