using api.Domain.Models;

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
        
        public string CombustivelDescricao { get; set; }
        
        public EnumTipoDeVeiculo TipoDeVeiculo { get; set; }

        public string TipoVeiculoDescricao { get; set; }
        
        public int Kilometragem { get; set; }

        public int MarcaId { get; set; }

        public string Marca { get; set; }

        public int ModeloId { get; set; }

        public string Modelo { get; set; }

        public string Motor { get; set; }

        public string Imagem { get; set; }

    }
}
