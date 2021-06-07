using System.Threading;
using System.Threading.Tasks;
using ThopFood.API.Data.Entities;
using ThopFood.Shared.Dtos.Recipes;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetByIdAsync(int id);
        Task<int> CreateRecipeAsync(NewRecipeDto dto, CancellationToken cancellationToken);
        Task<bool> UpdateRecipeAsync(int id, UpdateRecipeDto dto, CancellationToken cancellationToken);
    }
}