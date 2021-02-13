using api.Domain.ViewModels;
using api.Models.Entities;
using AutoMapper;
using System;
using System.Globalization;

namespace api.Infrastructure.DtoHandler
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClienteViewModel, Cliente>()
               .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
               .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
               .ForMember(dest => dest.DiaDeNascimento, opt => opt.MapFrom(src => DateTime.ParseExact(src.DiaDeNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

           



        }
    }
}
