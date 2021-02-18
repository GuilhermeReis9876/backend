using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("LocacaoVeiculos")]
    public class LocacaoVeiculo : BaseModel
    {
        public int TotalHoras { get; set; }

        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public double ValorLocacao { get; set; }
        
        public double ValorFinal { get; set; }

        public EnumStatusLocacao Status { get; set; }
    }
}
