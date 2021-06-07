using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThopFood.API.Data.Entities;
using ThopFood.Shared.Requests.Utensil;
using ThopFood.Shared.Responses;

namespace ThopFood.API.AutoMappers
{
    public class UtensilProfile : Profile
    {
        public UtensilProfile()
        {
            CreateMap<CreateUtensilRequest, Utensil>();

            CreateMap<Utensil, UtensilResponse>();
        }
    }
}
