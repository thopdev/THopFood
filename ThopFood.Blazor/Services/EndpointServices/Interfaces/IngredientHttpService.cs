using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThopFood.Blazor.Models;
using ThopFood.Shared.Dtos.Ingredients;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public class IngredientHttpService : IIngredientService
    {
        private readonly IHttpService _httpService;
        private const string EndPoint = "Ingredient";

        public IngredientHttpService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            var result = await _httpService.GetAsync<List<IngredientResponse>>(EndPoint);

            return result.Select(i => new Ingredient
            {
                Id = i.Id,
                Name = i.Name,
                Type = i.Type
            }).ToList();
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            var result = await _httpService.GetAsync<IngredientResponse>(EndPoint, id);

            return new Ingredient
            {
                Id = id,
                Name = result.Name,
                Type = result.Type
            };
        }
    }
}
