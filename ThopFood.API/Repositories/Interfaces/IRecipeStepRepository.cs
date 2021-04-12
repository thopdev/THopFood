using System.Threading;
using System.Threading.Tasks;
using ThopFood.Shared.Requests.RecipeStep;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IRecipeStepRepository
    {
        Task<int> CreateAsync(int id, CreateRecipeStepRequest dto, CancellationToken cancellationToken);
    }
}
