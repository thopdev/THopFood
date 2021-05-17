using System.Threading;
using System.Threading.Tasks;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IRecipeIngredientRepository
    {
        Task AddOrUpdateAsync(int recipeId, int ingredientId, int amount, CancellationToken cancellationToken);
        Task DeleteAsync(int recipeId, int ingredientId, CancellationToken cancellationToken);
    }
}