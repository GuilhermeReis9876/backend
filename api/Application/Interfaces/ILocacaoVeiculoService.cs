

using api.Domain.ViewModels;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILocacaoVeiculoService
    {
        Task<LocacaoVeiculoViewModel> Agendar(LocacaoVeiculoViewModel locacaoVeiculoVM);
        Task<SimulacaoViewModel> Simular(SimulacaoViewModel simulacaoVM);
    }
}