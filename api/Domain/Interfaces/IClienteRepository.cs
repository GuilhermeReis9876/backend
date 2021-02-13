using System.Threading.Tasks;
using api.Models.Entities;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<Cliente> UserExists(string register);
    }
}
