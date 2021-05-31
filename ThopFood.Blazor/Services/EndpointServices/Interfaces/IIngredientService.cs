using System.Collections.Generic;
using System.Threading.Tasks;
using ThopFood.Blazor.Models;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetIngredientById(int id);

    }
}