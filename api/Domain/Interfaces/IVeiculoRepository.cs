using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;

namespace api.Domain.Interfaces
{
    public interface IVeiculoRepository : IGenericRepository<Veiculo>
    {
        Task<IEnumerable<Veiculo>> GetVeiculosByCategoria(EnumTipoDeVeiculo id);
    }
}
