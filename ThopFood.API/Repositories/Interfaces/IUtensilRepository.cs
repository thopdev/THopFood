using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ThopFood.API.Data.Entities;
using ThopFood.Shared.Requests.Utensil;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IUtensilRepository
    {
        Task<List<Utensil>> GetAllAsync(CancellationToken cancellationToken);
        Task<Utensil> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<int> CreateAsync(CreateUtensilRequest dto, CancellationToken cancellationToken);
        Task<int> AddToRecipeAsync(int recipeId, int utensilId, CancellationToken cancellationToken);
    }
}