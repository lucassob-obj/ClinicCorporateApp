﻿using AutoMapper;
using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews;
using System;

namespace ClinicCorporateApp.Manager.Mappings
{
    public class AlteraClienteMappingProfile : Profile
    {
        public AlteraClienteMappingProfile()
        {
            CreateMap<AlteraCliente, Cliente>()
                .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
        }
    }
}
