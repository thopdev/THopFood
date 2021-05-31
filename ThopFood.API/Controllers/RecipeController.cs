﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Dtos.EntityCreated;
using ThopFood.Shared.Dtos.Recipes;
using ThopFood.Shared.Dtos.RecipeSteps;
using ThopFood.Shared.Requests.RecipeIngredient;

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

        [HttpGet("{id:int}", Name = nameof(Index))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RecipeDto>> Index(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

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
                Ingredients = recipe.Ingredients.Select(x => new RecipeIngredientDto{Amount = x.Amount, Id = x.IngredientId}).ToArray(),
                OwnerId = recipe.OwnerId,
                Steps = recipe.Steps.Select(x => new RecipeStepDto{Text = x.Id.ToString()}).ToArray(),
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EntityCreateDto>> Create([FromBody] NewRecipeDto newRecipe, CancellationToken cancellationToken)
        {
            var id = await _recipeRepository.CreateRecipeAsync(newRecipe, cancellationToken);
         
            return CreatedAtAction(nameof(Index), new {id}, new EntityCreateDto(id));
        }




        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRecipeDto recipeDto, CancellationToken cancellationToken)
        {
            var updated = await _recipeRepository.UpdateRecipeAsync(id, recipeDto, cancellationToken);

            if (updated)
            {
                return Ok();
            }

            return NotFound();
        }
    }

    [Route("api/recipe/{recipeId:int}/ingredient")]
    [ApiController]

    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;

        public RecipeIngredientController(IRecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
        }


        [HttpPut("{ingredientId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateIngredient(int recipeId, int ingredientId, AddOrUpdateRecipeIngredientRequest requestBody, CancellationToken cancellationToken)
        {
            await _recipeIngredientRepository.AddOrUpdateAsync(recipeId, ingredientId, requestBody.Amount,
                cancellationToken);

            return Ok();
        }

        [HttpDelete("{ingredientId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteIngredient(int recipeId, int ingredientId, CancellationToken cancellationToken)
        {
            try
            {
                await _recipeIngredientRepository.DeleteAsync(recipeId, ingredientId,
                    cancellationToken);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}