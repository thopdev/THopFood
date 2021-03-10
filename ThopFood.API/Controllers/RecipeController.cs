﻿using Microsoft.AspNetCore.Mvc;
using ThopFood.Shared.Dtos.Recipes;
using ThopFood.Shared.Dtos.RecipeSteps;

namespace ThopFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        [HttpGet("{id:int}")]
        public RecipeDto Index(int id)
        {
            return new RecipeDto
            {
                Id = id,
                Title = "Food!!!!",
                Description = "Very nice food",
                Favorite = true,
                ImageUrl = "https://scx1.b-cdn.net/csz/news/800a/2016/howcuttingdo.jpg",
                IngredientIds = new[] {5, 4},
                OwnerId = 5,
                Steps = new[] {new RecipeStepDto {Text = "Step one"}},
                UtensilIds = new[] {1, 2}
            };
        }
    }
}
