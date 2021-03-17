using System.Threading.Tasks;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;

namespace ThopFood.API.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;

        public RecipeRepository(ApplicationDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            return await _databaseContext.Recipes.FindAsync(id);
        }
    }
}