using api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Domain.ViewModels
{
    public class SimulacaoViewModel
    {
        public Veiculo veiculo { get; set; }

        public DateTime Entrada { get; set; }

        public DateTimeOffset Saida { get; set; }

        public double ValorSimulado { get; set; }
    }
}
