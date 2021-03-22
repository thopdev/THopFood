using System.Threading;
using System.Threading.Tasks;
using ThopFood.API.Data.Entities;
using ThopFood.Shared.Dtos.Recipes;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<int> CreateRecipeAsync(NewRecipeDto dto, CancellationToken cancellationToken);
    }
}