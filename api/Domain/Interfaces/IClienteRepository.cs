using api.Domain.Models;
using System.Threading.Tasks;

namespace api.Domain.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<Cliente> UserExists(string register);
    }
}
