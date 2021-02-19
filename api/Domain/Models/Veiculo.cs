using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Veiculos")]
    public class Veiculo : BaseModel
    {
        public string Placa { get; set; }

        public DateTime Ano { get; set; }

        public double ValorHora { get; set; }

        public int LimitePortaMalas { get; set; }

        public EnumTipoDeCombustivel TipoDeCombustivel { get; set; }

        public EnumTipoDeVeiculo TipoDeVeiculo { get; set; }

        [ForeignKey("Modelo")]
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        public int Kilometragem { get; set; }

        public bool EstaLocado { get; set; }

        public string Motor { get; set; }
        public string Imagem { get; set; }
    }
}
