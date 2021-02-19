using api.Domain.Models;
using api.Domain.ViewModels;
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

            CreateMap<Veiculo, VeiculoViewModel>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Placa))
              .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Ano.ToString("yyyy")))
              .ForMember(dest => dest.ValorHora, opt => opt.MapFrom(src => src.ValorHora))
              .ForMember(dest => dest.LimitePortaMalas, opt => opt.MapFrom(src => src.LimitePortaMalas))
              .ForMember(dest => dest.TipoDeCombustivel, opt => opt.MapFrom(src => src.TipoDeCombustivel))
              .ForMember(dest => dest.TipoDeVeiculo, opt => opt.MapFrom(src => src.TipoDeVeiculo))
              .ForMember(dest => dest.LimitePortaMalas, opt => opt.MapFrom(src => src.LimitePortaMalas))
              .ForMember(dest => dest.Kilometragem, opt => opt.MapFrom(src => src.Kilometragem))
              .ForMember(dest => dest.EstaLocado, opt => opt.MapFrom(src => src.EstaLocado))
              .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Modelo.Name))
              .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Modelo.Marca.Name));

            CreateMap<Modelo, ModeloViewModel>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.MarcaId, opt => opt.MapFrom(src => src.MarcaId));

            CreateMap<Marca, MarcaViewModel>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name));

            CreateMap<LocacaoVeiculoViewModel, LocacaoVeiculo>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.DataLocacao, opt => opt.MapFrom(src => src.DataLocacao))
                .ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src => src.DataDevolucao))
                .ForMember(dest => dest.TotalHoras, opt => opt.MapFrom(src => src.TotalHoras));

            CreateMap<CheckList, CheckListViewModel>()
              .ForMember(dest => dest.EstaLimpo, opt => opt.MapFrom(src => src.EstaLimpo))
              .ForMember(dest => dest.EstaComTanqueCheio, opt => opt.MapFrom(src => src.EstaComTanqueCheio))
              .ForMember(dest => dest.EstaSemAmassados, opt => opt.MapFrom(src => src.EstaSemAmassados))
              .ForMember(dest => dest.EstaSemArranhoes, opt => opt.MapFrom(src => src.EstaSemArranhoes))
              .ForMember(dest => dest.LocacaoVeiculoId, opt => opt.MapFrom(src => src.LocacaoVeiculoId));

            CreateMap<Cliente, UserInfoViewModel>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Register, opt => opt.MapFrom(src => src.Cpf))
              .ForMember(dest => dest.TipoDeUsuario, opt => opt.MapFrom(src => src.TipoDeUsuario));

            CreateMap<Operador, UserInfoViewModel>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Register, opt => opt.MapFrom(src => src.Matricula))
              .ForMember(dest => dest.TipoDeUsuario, opt => opt.MapFrom(src => src.TipoDeUsuario));

            CreateMap<Veiculo, ReservaViewModel>()
              .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Placa))
              .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Ano.ToString("yyyy")))
              .ForMember(dest => dest.ValorHora, opt => opt.MapFrom(src => src.ValorHora))
              .ForMember(dest => dest.LimitePortaMalas, opt => opt.MapFrom(src => src.LimitePortaMalas))
              .ForMember(dest => dest.TipoDeCombustivel, opt => opt.MapFrom(src => src.TipoDeCombustivel))
              .ForMember(dest => dest.TipoDeVeiculo, opt => opt.MapFrom(src => src.TipoDeVeiculo))
              .ForMember(dest => dest.LimitePortaMalas, opt => opt.MapFrom(src => src.LimitePortaMalas))
              .ForMember(dest => dest.Kilometragem, opt => opt.MapFrom(src => src.Kilometragem))
              .ForMember(dest => dest.EstaLocado, opt => opt.MapFrom(src => src.EstaLocado))
              .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Modelo.Name))
              .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Modelo.Marca.Name));

            CreateMap<LocacaoVeiculo, ReservaViewModel>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.DataLocacao, opt => opt.MapFrom(src => src.DataLocacao))
                .ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src => src.DataDevolucao))
                .ForMember(dest => dest.ValorLocacao, opt => opt.MapFrom(src => src.ValorLocacao))
                .ForMember(dest => dest.ValorFinal, opt => opt.MapFrom(src => src.ValorFinal))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.TotalHoras, opt => opt.MapFrom(src => src.TotalHoras));


            


        }
    }
}
