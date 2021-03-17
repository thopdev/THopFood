using System.Threading.Tasks;
using ThopFood.API.Data.Entities;

namespace ThopFood.API.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetById(int id);
    }
}