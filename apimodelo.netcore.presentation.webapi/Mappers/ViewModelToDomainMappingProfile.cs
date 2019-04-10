using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apimodelo.netcore.domain.domain.Models;
using apimodelo.netcore.presentation.webapi.Models;
using AutoMapper;

namespace apimodelo.netcore.presentation.webapi.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LoginViewModel, Usuario>();
        }
    }
}