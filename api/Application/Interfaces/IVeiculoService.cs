using api.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> GetVeiculos();

        Task<Veiculo> GetVeiculoById(int id);
    }
}
