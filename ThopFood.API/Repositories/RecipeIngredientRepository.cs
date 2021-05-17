using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;

namespace ThopFood.API.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly ApplicationDatabaseContext _applicationDatabaseContext;

        private DbSet<RecipeIngredient> RecipeIngredients => _applicationDatabaseContext.RecipeIngredients;

        public RecipeIngredientRepository(ApplicationDatabaseContext applicationDatabaseContext)
        {
            _applicationDatabaseContext = applicationDatabaseContext;
        }

        public async Task AddOrUpdateAsync(int recipeId, int ingredientId, int amount, CancellationToken cancellationToken)
        {
            var recipeIngredient = await RecipeIngredients.FindAsync(new object[]{recipeId, ingredientId}, cancellationToken) ;

            if (recipeIngredient is not null)
            {
                recipeIngredient.Amount = amount;
                await _applicationDatabaseContext.SaveChangesAsync(cancellationToken);
                return;
            }

            await RecipeIngredients.AddAsync(new RecipeIngredient
            {
                Amount = amount,
                IngredientId = ingredientId,
                RecipeId = recipeId
            }, cancellationToken);

            await _applicationDatabaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int recipeId, int ingredientId, CancellationToken cancellationToken)
        {
            var recipeIngredient = await RecipeIngredients.FindAsync(new object[] { recipeId, ingredientId}, cancellationToken);
            
            if (recipeIngredient is null)
            {
                throw new KeyNotFoundException();
            }

            RecipeIngredients.Remove(recipeIngredient);
            await _applicationDatabaseContext.SaveChangesAsync(cancellationToken);
        }


    }
}
