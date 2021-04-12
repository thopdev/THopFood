﻿using AutoMapper;
using ThopFood.Blazor.Models.Recipe.Create;
using ThopFood.Blazor.Services.EndpointServices.Interfaces;
using ThopFood.Shared.Dtos.EntityCreated;
using ThopFood.Shared.Dtos.Recipes;
using ThopFood.Shared.Requests.RecipeStep;

namespace ThopFood.Blazor.Services.EndpointServices
{
    public class RecipeStepHttpService : IRecipeStepHttpService
    {
        private const string recipe = "recipe";
        private const string step = "step";
        
        private readonly IHttpService _httpService;
        private readonly IMapper _mapper;

        public RecipeStepHttpService(IHttpService httpService, IMapper mapper)
        {
            _httpService = httpService;
            _mapper = mapper;
        }

        public void CreateAsync(int recipeId, CreateRecipeStep stepModel)
        {
            var request = _mapper.Map<CreateRecipeStepRequest>(stepModel);

            _httpService.PostAsync<EntityCreateDto>($"{recipe}/{recipeId}/{step}", request);
        }
    }
}
