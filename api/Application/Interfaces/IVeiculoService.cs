using api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> GetVeiculos();

        Task<Veiculo> GetVeiculoById(int id);

        Task<IEnumerable<Veiculo>> GetVeiculoByCategoria(EnumTipoDeVeiculo id);
    }
}
