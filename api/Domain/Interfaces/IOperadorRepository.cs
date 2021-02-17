using api.Domain.Models;
using System.Threading.Tasks;

namespace api.Domain.Interfaces
{
    public interface IOperadorRepository : IGenericRepository<Operador>
    {
        Task<Operador> UserExists(string register);

    }
}
