using System.Threading.Tasks;
using ThopFood.API.Data.Entities;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeById(int id);
    }
}