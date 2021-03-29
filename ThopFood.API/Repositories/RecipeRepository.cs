using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ThopFood.API.Data;
using ThopFood.API.Data.Entities;
using ThopFood.API.Repositories.Interfaces;
using ThopFood.Shared.Dtos.Recipes;

namespace ThopFood.API.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public RecipeRepository(ApplicationDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
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

        public async Task<bool> UpdateRecipeAsync(int id, UpdateRecipeDto dto, CancellationToken cancellationToken)
        {
            var entity = await GetRecipeByIdAsync(id);

            if (entity == null)
            {
                return false;
            }
            _mapper.Map<Recipe>(dto);

            await _databaseContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}