using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Dtos.Ingredients;
using ThopFood.Shared.Enums;

namespace ThopFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientController(IIngredientRepository ingredientRepository)
        {
            this._ingredientRepository = ingredientRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IngredientDto>> Index(int id)
        {
            var ingredient = await _ingredientRepository.GetById(id);

            if (ingredient == null)
            {
                return NotFound($"{nameof(Ingredient)} not found");
            }

            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Type = ingredient.Type
            };
        }
    }
}
