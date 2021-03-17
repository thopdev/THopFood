using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Dtos.Recipes;
using ThopFood.Shared.Dtos.RecipeSteps;

namespace ThopFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RecipeDto>> Index(int id)
        {
            var recipe = await _recipeRepository.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound($"{nameof(Recipe)} not found!");
            }

            return Ok(new RecipeDto
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients.Select(x => new RecipeIngredientDto{Amount = x.Amount, Id = x.RecipeId}).ToArray(),
                OwnerId = recipe.OwnerId,
                Steps = recipe.Steps.Select(x => new RecipeStepDto{Text = x.Id.ToString()}).ToArray(),
            });
        }
    }
}