using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Requests.Utensil;

namespace ThopFood.API.Repositories
{
    public class UtensilRepository : IUtensilRepository
    {
        private readonly ApplicationDatabaseContext _applicationDatabaseContext;
        private readonly IRecipeRepository _recipeRepository;

        public UtensilRepository(ApplicationDatabaseContext applicationDatabaseContext, IRecipeRepository recipeRepository)
        {
            _applicationDatabaseContext = applicationDatabaseContext;
            _recipeRepository = recipeRepository;
        }

        public async Task<List<Utensil>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationDatabaseContext.Utensils.ToListAsync(cancellationToken);
        }

        public async Task<Utensil> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _applicationDatabaseContext.Utensils.Where(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> CreateAsync(CreateUtensilRequest dto, CancellationToken cancellationToken)
        {
            var utensil = new Utensil {Name = dto.Name};
            var result = await _applicationDatabaseContext.Utensils.AddAsync(utensil, cancellationToken);
            await _applicationDatabaseContext.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;
        }

        public async Task<int> AddToRecipeAsync(int recipeId, int utensilId, CancellationToken cancellationToken)
        {
            var utensil = await GetByIdAsync(utensilId, cancellationToken);
            var recipe = await _recipeRepository.GetByIdAsync(recipeId);
            utensil.Recipes.Add(recipe);

            await _applicationDatabaseContext.SaveChangesAsync(cancellationToken);
            return recipeId;
        }
    }
}