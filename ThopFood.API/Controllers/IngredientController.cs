using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Dtos.Ingredients;
using ThopFood.Shared.Requests.Ingredient;
using ThopFood.Shared.Responses.EntityCreated;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IngredientResponse>> GetAll()
        {
            return Ok(await _ingredientRepository.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IngredientResponse>> Index(int id)
        {
            var ingredient = await _ingredientRepository.GetById(id);

            if (ingredient == null)
            {
                return NotFound($"{nameof(Ingredient)} not found");
            }

            return new IngredientResponse
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Type = ingredient.Type
            };
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EntityCreateResponse>> Create([FromBody] NewIngredientRequest requestBody, CancellationToken cancellationToken)
        {
            var id = await _ingredientRepository.CreateRecipeAsync(requestBody, cancellationToken);

            return CreatedAtAction(nameof(Index), new { id }, new EntityCreateResponse(id));
        }
    }
}
