using Microsoft.AspNetCore.Mvc;
using ThopFood.Shared.Dtos.Ingredients;
using ThopFood.Shared.Enums;

namespace ThopFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IngredientDto Index(int id)
        {
            return new IngredientDto
            {
                Id = id,
                Name = "New ingredient",
                Type = IngredientType.Amount
            };
        }
    }
}
