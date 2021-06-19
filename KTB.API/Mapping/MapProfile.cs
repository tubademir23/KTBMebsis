using AutoMapper;
using KTB.API.DTOs;
using KTB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Meslek, MeslekDto>();
            CreateMap<MeslekDto, Meslek>();
            CreateMap<Uye, UyeDto>();
            CreateMap<UyeDto, Uye>();
            CreateMap<UyeWithEserDto, Uye>();
            CreateMap<Eser, EserDto>();
            CreateMap<EserDto, Eser>();
            CreateMap<EserWithUyeDto, Eser>();
        }

    }
}
