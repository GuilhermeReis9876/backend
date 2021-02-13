using api.Models.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<Cliente> UserExists(string register);
    }
}
