using System;
using System.Threading;
using System.Threading.Tasks;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Requests.RecipeStep;

namespace ThopFood.API.Repositories
{
    public class RecipeStepRepository : IRecipeStepRepository
    {
        private readonly ApplicationDatabaseContext _applicationDatabaseContext;

        public RecipeStepRepository(ApplicationDatabaseContext applicationDatabaseContext)
        {
            _applicationDatabaseContext = applicationDatabaseContext;
        }

        public async Task<int> CreateAsync(int id, CreateRecipeStepRequest dto, CancellationToken cancellationToken)
        {
            var entity = new RecipeStep {RecipeId = id, Text = dto.Text};
            var result = await _applicationDatabaseContext.RecipeSteps.AddAsync(entity, cancellationToken);

            await _applicationDatabaseContext.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;
        }
    }
}
