using api.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientes();

        Task<Cliente> GetById(int id);

        Task Save(Cliente cliente);

        Task Delete(Cliente cliente);

        Task Update(Cliente cliente);
    }
}