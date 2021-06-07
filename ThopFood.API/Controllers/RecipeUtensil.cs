using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.API.Validators.Utensil;
using ThopFood.Shared.Responses.EntityCreated;

namespace ThopFood.API.Controllers
{
    [Route("api/" + nameof(Recipe) + "/{recipeId:int:required}")]
    [ApiController]
    public class RecipeUtensilController : ControllerBase
    {

        private readonly IUtensilRepository _utensilRepository;

        public RecipeUtensilController(IUtensilRepository utensilRepository)
        {
            _utensilRepository = utensilRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EntityCreateResponse>> Create([FromRoute] int recipeId, [FromBody] AddUtensilToRecipeRequest request,
            CancellationToken cancellationToken)
        {
            var id = await _utensilRepository.AddToRecipeAsync(recipeId, request.Id, cancellationToken);
            return CreatedAtAction(nameof(RecipeController.Index), nameof(RecipeController), new { Id = id }, new EntityCreateResponse(id));
        }
    }
}
