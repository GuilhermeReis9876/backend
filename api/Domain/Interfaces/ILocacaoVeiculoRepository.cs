using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain.Models;

namespace api.Domain.Interfaces
{
    public interface ILocacaoVeiculoRepository : IGenericRepository<LocacaoVeiculo>
    {
        Task<IEnumerable<object>> GetReservas();

        Task<IEnumerable<object>> GetReservasByCliente(int id);

    }
}
