using api.Domain.ViewModels;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface ILocacaoVeiculoService
    {
        Task<LocacaoVeiculoViewModel> Agendar(LocacaoVeiculoViewModel locacaoVeiculoVM);
        Task<SimulacaoViewModel> Simular(SimulacaoViewModel simulacaoVM);
    }
}