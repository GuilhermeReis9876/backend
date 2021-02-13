using api.Models.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOperadorRepository : IGenericRepository<Operador>
    {
        Task<Operador> UserExists(string register);

    }
}
