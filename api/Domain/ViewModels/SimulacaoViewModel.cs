using System;

namespace api.Domain.ViewModels
{
    public class SimulacaoViewModel
    {
        public int VeiculoId { get; set; }

        public DateTime Entrada { get; set; }

        public DateTimeOffset Saida { get; set; }

        public double ValorSimulado { get; set; }

        public int TotalHoras { get; set; }

        public string Error { get; set; }

    }
}
