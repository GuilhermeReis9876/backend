using api.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface ILocacaoVeiculoService
    {
        Task<LocacaoVeiculoViewModel> Agendar(LocacaoVeiculoViewModel locacaoVeiculoVM, string token);
        Task<SimulacaoViewModel> Simular(SimulacaoViewModel simulacaoVM);
        Task<IEnumerable<ReservaViewModel>> GetReservas();
        Task<IEnumerable<ReservaViewModel>> GetReservasByCliente(string token);
    }
}