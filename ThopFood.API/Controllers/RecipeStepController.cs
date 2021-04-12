using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Dtos.EntityCreated;
using ThopFood.Shared.Requests.RecipeStep;

namespace ThopFood.API.Controllers
{
    [ApiController]
    [Route("api/recipe/{recipeId:int}/step")]
    public class RecipeStepController : ControllerBase
    {
        private readonly IRecipeStepRepository _recipeStepRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeStepController(IRecipeStepRepository recipeStepRepository, IRecipeRepository recipeRepository)
        {
            _recipeStepRepository = recipeStepRepository;
            _recipeRepository = recipeRepository;
        }

        [HttpGet("{stepId:int}")]
        public async Task<ActionResult> Index(int recipeId, int stepId)
        {
            return NotFound();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityCreateDto>> Create(int recipeId, [FromBody] CreateRecipeStepRequest request, CancellationToken cancellationToken)
        {
            if ((await _recipeRepository.GetRecipeByIdAsync(recipeId) == null))
            {
                return NotFound();
            }


            var id = await _recipeStepRepository.CreateAsync(recipeId, request, cancellationToken);

            return CreatedAtAction(nameof(Index), new { RecipeId = recipeId, StepId = id }, new EntityCreateDto(id));
        }
    }
}
