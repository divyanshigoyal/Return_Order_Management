using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProcessRequest, ProcessRequestToReturnDto>()
                .ForMember(d => d.ComponentName, o => o.MapFrom(s => s.ComponentDetail.ComponentName))
                .ForMember(d => d.ComponentType, o => o.MapFrom(s => s.ComponentDetail.ComponentType))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.ComponentDetail.Quantity));
        }
    }
}