using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;

namespace ThopFood.API.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;

        public IngredientRepository(ApplicationDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Ingredient> GetById(int id)
        {
            return await _databaseContext.Ingredients.FindAsync(id);
        }

    }
}
