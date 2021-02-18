using api.Domain.Models;
using System;
using System.Collections.Generic;

namespace api.Domain.ViewModels
{
    public class LocacaoVeiculoViewModel
    {
        public int TotalHoras { get; set; }

        public int VeiculoId { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }

        public double ValorLocacao { get; set; }

        public double ValorFinal { get; set; }

        public ICollection<string> LocacoesConflitantes { get; set; }/* = new HashSet<string>();*/

        public string Error { get; set; }

        public EnumStatusLocacao? Status { get; set; }

    }
}
