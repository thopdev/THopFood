using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;
using ThopFood.Shared.Responses.EntityCreated;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public abstract class HttpRepositoryBase<TModel, TResponse, TRequest> : IHttpRepository<TModel, TResponse, TRequest>
    {
        protected abstract string EndPoint { get; }
        protected readonly IHttpService HttpService;
        protected readonly IMapper Mapper;

        protected HttpRepositoryBase(IHttpService httpService, IMapper mapper)
        {
            HttpService = httpService;
            Mapper = mapper;
        }

        public async Task<int> CreateAsync(TRequest model)
        {
            var response = await HttpService.PostAsync<EntityCreateResponse>(EndPoint, model);
            return response.Id;
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            var response = await HttpService.GetAsync<List<TResponse>>(EndPoint);
            return Mapper.Map<List<TModel>>(response);
        }

        public async Task<TModel> GetById(int id)
        {
            var response = await HttpService.GetAsync<TResponse>(EndPoint, id);
            return Mapper.Map<TModel>(response);
        }
    }
}