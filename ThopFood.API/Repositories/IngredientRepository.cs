using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Requests.Ingredient;
using ThopFood.Shared.Requests.RecipeIngredient;

namespace ThopFood.API.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;

        public IngredientRepository(ApplicationDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _databaseContext.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetById(int id)
        {
            return await _databaseContext.Ingredients.FindAsync(id);
        }

        public async Task<int> CreateRecipeAsync(NewIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient {Name = request.Name, Type = request.Type};
            var result= await _databaseContext.Ingredients.AddAsync(ingredient, cancellationToken);
            await _databaseContext.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;
        }
    }
}
