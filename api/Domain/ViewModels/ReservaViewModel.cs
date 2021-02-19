using api.Domain.Models;
using System;
using System.Collections.Generic;

namespace api.Domain.ViewModels
{
    public class ReservaViewModel
    {
        public int TotalHoras { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public double ValorLocacao { get; set; }

        public double ValorFinal { get; set; }

        public string Error { get; set; }

        public EnumStatusLocacao? Status { get; set; }

        public int VeiculoId { get; set; }

        public string Placa { get; set; }

        public string Ano { get; set; }

        public double ValorHora { get; set; }

        public int LimitePortaMalas { get; set; }

        public EnumTipoDeCombustivel TipoDeCombustivel { get; set; }

        public EnumTipoDeVeiculo TipoDeVeiculo { get; set; }

        public int Kilometragem { get; set; }

        public bool EstaLocado { get; set; }

        public int MarcaId { get; set; }

        public string Marca { get; set; }

        public int ModeloId { get; set; }

        public string Modelo { get; set; }

    }
}
