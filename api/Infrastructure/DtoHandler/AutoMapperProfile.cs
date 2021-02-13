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
            CreateMap<UsuarioUpdateViewModel, Cliente>()
               .ForMember(dest => dest.DiaDeNascimento, opt => opt.MapFrom(src => DateTime.ParseExact(src.DiaDeNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
               .ForMember(des => des.Endereco, opt => opt.MapFrom(stc => stc.Endereco));

            CreateMap<UsuarioUpdateViewModel, Operador>()
              .ForMember(dest => dest.DiaDeNascimento, opt => opt.MapFrom(src => DateTime.ParseExact(src.DiaDeNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
              .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
              .ForMember(des => des.Endereco, opt => opt.MapFrom(stc => stc.Endereco));

            CreateMap<Operador, UsuarioResponseViewModel>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Matricula, opt => opt.MapFrom(src => src.Matricula))
             .ForMember(dest => dest.DiaDeNascimento, opt => opt.MapFrom(src => src.DiaDeNascimento.ToString("dd/MM/yyyy")))
             .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
             .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoDeUsuario))
             .ForMember(dest => dest.TipoUsuarioDescricao, opt => opt.MapFrom(src => src.TipoDeUsuario.ToString()));

            CreateMap<Cliente, UsuarioResponseViewModel>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
               .ForMember(dest => dest.DiaDeNascimento, opt => opt.MapFrom(src => src.DiaDeNascimento.ToString("dd/MM/yyyy")))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
               .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.TipoDeUsuario))
               .ForMember(dest => dest.TipoUsuarioDescricao, opt => opt.MapFrom(src => src.TipoDeUsuario.ToString()));

        }
    }
}
