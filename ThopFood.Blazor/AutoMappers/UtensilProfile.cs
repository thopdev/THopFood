using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThopFood.Blazor.Models;
using ThopFood.Shared.Responses;

namespace ThopFood.Blazor.AutoMappers
{
    public class UtensilProfile : Profile
    {
        public UtensilProfile()
        {
            CreateMap<UtensilResponse, Utensil>();
        }
    }
}
