using System.Threading.Tasks;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public interface IIngredientService
    {
        Task<Ingredient> GetIngredientById(int id);
    }
}