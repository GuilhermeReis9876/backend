using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models.Entities;

namespace Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> GetVeiculos();

        Task<Veiculo> GetVeiculoById(int id);
    }
}
