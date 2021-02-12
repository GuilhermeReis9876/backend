using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Entities
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

        public bool EstaLocado { get; set; }

        [ForeignKey("Checklist")]
        public int CheckelistId { get; set; }
        public CheckList CheckList { get; set; }
    }
}
