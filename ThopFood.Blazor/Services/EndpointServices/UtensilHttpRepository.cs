using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ThopFood.Blazor.Models;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;
using ThopFood.Shared.Requests.Utensil;
using ThopFood.Shared.Responses;
using ThopFood.Shared.Responses.EntityCreated;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public class UtensilHttpRepository : HttpRepositoryBase<Utensil, UtensilResponse, CreateUtensilRequest>, IUtensilRepository
    {
        public UtensilHttpRepository(IHttpService httpService, IMapper mapper) : base(httpService, mapper)
        {
        }

        protected override string EndPoint => "utensil";

        public async Task AddToIngredientAsync(int recipeId, int utensilId)
        {
            var response = await HttpService.PostAsync<EntityCreateResponse>($"Recipe/{recipeId}/{EndPoint}",
                new AddUtensilToRecipeRequest {Id = utensilId});
        }

    }
}
