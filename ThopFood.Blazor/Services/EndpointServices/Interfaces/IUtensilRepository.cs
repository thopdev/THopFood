using System.Collections.Generic;
using System.Threading.Tasks;
using ThopFood.Blazor.Models;
using ThopFood.Shared.Requests.Utensil;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public interface IUtensilRepository
    {
        Task<int> CreateAsync(CreateUtensilRequest model);
        Task<List<Utensil>> GetAllAsync();
        Task<Utensil> GetById(int id);
    }
}