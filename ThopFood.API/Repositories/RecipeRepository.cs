using System.Threading;
using System.Threading.Tasks;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Dtos.Recipes;

namespace ThopFood.API.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;

        public RecipeRepository(ApplicationDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _databaseContext.Recipes.FindAsync(id);
        }

        public async Task<int> CreateRecipeAsync(NewRecipeDto dto, CancellationToken cancellationToken)
        {
            var recipe = new Recipe
            {
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                CookTime = dto.CookTime,
                PrepTime = dto.PrepTime,
                DefaultServingSize = dto.DefaultServingSize,
                OwnerId = 1
            };

            var result = await _databaseContext.Recipes.AddAsync(recipe, cancellationToken);
            
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
    }
}