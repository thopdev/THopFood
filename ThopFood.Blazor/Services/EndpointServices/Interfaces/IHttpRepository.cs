using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThopFood.Blazor.Services.EndpointServices.Interfaces
{
    public interface IHttpRepository<TModel, TResponse, in TRequest>
    {
        public Task<List<TModel>> GetAllAsync();
        public Task<TModel> GetById(int id);

        public Task<int> CreateAsync(TRequest model);
    }
}