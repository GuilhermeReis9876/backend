using System;
using api.Models.Entities;

namespace api.Domain.ViewModels
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }

        public string Placa { get; set; }

        public string Ano { get; set; }

        public double ValorHora { get; set; }

        public int LimitePortaMalas { get; set; }

        public EnumTipoDeCombustivel TipoDeCombustivel { get; set; }

        public EnumTipoDeVeiculo TipoDeVeiculo { get; set; }

        public int Kilometragem { get; set; }

        public bool EstaLocado { get; set; }

        public int MarcaId {get ;set ;}

        public string Marca {get;set;}

        public int ModeloId { get; set; }

        public string Modelo { get; set; }

    }
}
