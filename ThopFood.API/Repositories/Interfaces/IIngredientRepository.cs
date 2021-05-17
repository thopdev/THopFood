using System.Threading;
using System.Threading.Tasks;
using ThopFood.API.Data.Entities;
using ThopFood.Shared.Requests.Ingredient;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetById(int id);
        Task<int> CreateRecipeAsync(NewIngredientRequest dto, CancellationToken cancellationToken);
    }
}