using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("CheckLists")]
    public class CheckList : BaseModel
    {
        public bool EstaLimpo { get; set; }

        public bool EstaComTanqueCheio { get; set; }

        public bool EstaSemAmassados { get; set; }

        public bool EstaSemArranhoes { get; set; }

        [ForeignKey("LocacaoVeiculo")]
        public int LocacaoVeiculoId { get; set; }

        public LocacaoVeiculo LocacaoVeiculo { get; set; }

        [ForeignKey("Operador")]
        public int OperadorId { get; set; }

        public Operador Operador { get; set; }

        public bool CheckListInicial { get; set; }


    }
}
