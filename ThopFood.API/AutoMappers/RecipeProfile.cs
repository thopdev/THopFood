using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThopFood.API.Data.Entities;
using ThopFood.Shared.Dtos.Recipes;

namespace ThopFood.API.AutoMappers
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<NewRecipeDto, Recipe>();
            CreateMap<UpdateRecipeDto, Recipe>();
        }

    }
}
